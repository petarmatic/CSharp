import { Form, Row, Col, Button } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Service from '../../services/ObavijestService';
import { RouteNames } from '../../constants';
import PredmetService from '../../services/PredmetService';
import useError from '../../hooks/useError';



export default function ObavijestiPromjena() {
  const navigate = useNavigate();
  const routeParams = useParams(); 

  const [predmeti, setPredmeti] = useState([]);
  const [predmetId, setPredmetId] = useState(0);
  const [obavijest, setObavijest] = useState({});
  const { prikaziError } = useError();

  async function dohvatiPredmete() {
    const odgovor = await PredmetService.get();
    setPredmeti(odgovor.poruka);
  }

  async function dohvatiObavijest() {
    const odgovor = await Service.getById(routeParams.id);
    
    if (odgovor.greska) {
      prikaziError(odgovor.poruka);
      return;
    }
    
    const obavijest = odgovor.poruka;
    setObavijest(obavijest);
    setPredmetId(obavijest.predmetiId || 0);
  }

  async function dohvatiInicijalnePodatke() {
    await dohvatiPredmete();
    await dohvatiObavijest();
  }

  useEffect(() => {
    dohvatiInicijalnePodatke();
  }, []);

  async function promjena(e) {
    const odgovor = await Service.promjena(routeParams.id, e);
    
    if (odgovor.greska) {
      prikaziError(odgovor.poruka);
      return;
    }
    
    navigate(RouteNames.OBAVIJESTI_PREGLED);
  }

  function obradiSubmit(e) {
    e.preventDefault();
    
    const podaci = new FormData(e.target);
    
    promjena({
      tekst: podaci.get('tekst'),
      datum: podaci.get('datum'),
      predmetId: parseInt(podaci.get('predmet')) 
    });
  }

  return (
    <>
      <h2>Obavijesti promjena</h2>
      <Row>
        <Col sm={12} lg={6} md={6}>
          <Form onSubmit={obradiSubmit}>
            <Form.Group controlId="tekst">
              <Form.Label>Tekst obavijesti</Form.Label>
              <Form.Control 
                type="text" 
                name="tekst" 
                required 
                defaultValue={obavijest.tekst} 
              />
            </Form.Group>

            <Form.Group controlId="datum">
              <Form.Label>Datum</Form.Label>
              <Form.Control 
                type="date" 
                name="datum" 
                required 
                defaultValue={obavijest.datum} 
              />
            </Form.Group>

            <Form.Group controlId="predmet">
              <Form.Label>Predmet</Form.Label>
              <Form.Select 
                name="predmet"
                required 
                value={predmetId}
                onChange={(e) => setPredmetId(e.target.value)}
              >
                {predmeti.map((predmet) => (
                  <option key={predmet.id} value={predmet.id}>
                    {predmet.naziv}
                  </option>
                ))}
              </Form.Select>
            </Form.Group>

            <hr />
            <Row>
              <Col xs={6} sm={6} md={3} lg={6}>
                <Link to={RouteNames.OBAVIJESTI_PREGLED} className="btn btn-danger siroko">
                  Odustani
                </Link>
              </Col>
              <Col xs={6} sm={6} md={9} lg={6}>
                <Button variant="primary" type="submit" className="siroko">
                  Promjeni obavijest
                </Button>
              </Col>
            </Row>
          </Form>
        </Col>
      </Row>
    </>
  );
}
