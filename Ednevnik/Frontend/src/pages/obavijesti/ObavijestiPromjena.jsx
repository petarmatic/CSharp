import { Form, Row, Col, Button } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { useEffect, useState, useRef  } from 'react';
import Service from '../../services/ObavijestService';
import { RouteNames } from '../../constants';
import PredmetService from '../../services/PredmetService';
import useError from '../../hooks/useError';



export default function ObavijestiPromjena() {
  const navigate = useNavigate();
  const routeParams = useParams(); 
  const { prikaziError } = useError();

  const [predmeti, setPredmeti] = useState([]);
  const [predmetId, setPredmetId] = useState(0);

  const [obavijest, setObavijest] = useState({});
  
  const typeaheadRef = useRef(null);
  
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
    
    let obavijest = odgovor.poruka;
    setObavijest(obavijest);
    setPredmetId(obavijest.predmetiId);
  }

  async function dohvatiInicijalnePodatke() {
    await dohvatiPredmete();
    await dohvatiObavijest();
  }

  useEffect(() => {
    dohvatiInicijalnePodatke();
  }, []);

  async function promjena(obavijest) {
    const odgovor = await Service.promjena(routeParams.id, obavijest);

    if (odgovor.greska) {
        prikaziError(Array.isArray(odgovor.poruka) ? odgovor.poruka : [odgovor.poruka]);
        return;
    }

    alert("Obavijest je uspješno promijenjena!");
    navigate(RouteNames.OBAVIJESTI_PREGLED);
}

function obradiSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);

    const noviPodaci = {
        tekst: podaci.get('tekst'),
        datum: podaci.get('datum'),
        predmetId: parseInt(predmetId)
    };

    
    if (JSON.stringify(noviPodaci) === JSON.stringify(obavijest)) {
        prikaziError(["Nema promjena za spremiti."]); 
        return;
    }

    promjena(noviPodaci);
}

  return (
    <>
      <h2>Obavijesti promjena</h2>
      <Row>
        <Col key='1' sm={12} lg={6} md={6}>
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
                defaultValue={obavijest.datum?.split('T')[0]} 
              />
            </Form.Group>

            <Form.Group className='mb-3' controlId="predmetId">
                <Form.Label>Predmet</Form.Label>
                <Form.Select 
                    value={predmetId}
                    onChange={(e) => {setPredmetId(e.target.value)}}
                >
                   {predmeti&&predmeti.map((s,index)=>(
                    <option key={index} value={s.id}>
                    {s.naziv}
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