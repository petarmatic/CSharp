import { Form, Row, Col, Button } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Service from '../../services/OcjenaService';
import { RouteNames } from '../../constants';
import PredmetService from '../../services/PredmetService';
import useError from '../../hooks/useError';
import UcenikService from '../../services/UcenikService';

export default function ObavijestiPromjena() {
  const navigate = useNavigate();
  const routeParams = useParams(); 
  const { prikaziError } = useError();

  const [predmeti, setPredmeti] = useState([]);
  const [predmetId, setPredmetId] = useState(0);

  const [ucenici, setUcenici] = useState([]);
  const [ucenikId, setUcenikId] = useState(0);

  const [ocjena, setOcjena] = useState({});

  async function dohvatiPredmete() {
    const odgovor = await PredmetService.get();
    setPredmeti(odgovor.poruka);
  }

  async function dohvatiUcenike() {
    const odgovor = await UcenikService.get();
    setUcenici(odgovor.poruka);
  }

  async function dohvatiOcjene() {
    const odgovor = await Service.getById(routeParams.id);
    if (odgovor.greska) {
      prikaziError(odgovor.poruka);
      return;
    }
    
    let ocjene = odgovor.poruka;
    setOcjena(ocjene);
    setPredmetId(ocjene.predmetId); 
    setUcenikId(ocjene.ucenikId); 
  }

  async function dohvatiInicijalnePodatke() {
    await dohvatiPredmete();
    await dohvatiUcenike();
    await dohvatiOcjene();
  }

  useEffect(() => {
    dohvatiInicijalnePodatke();
  }, []);

  useEffect(() => {
    if (ocjena) {
      setPredmetId(ocjena.predmetId); 
      setUcenikId(ocjena.ucenikId); 
    }
  }, [ocjena]);

  async function promjena(ocjena) {
    const odgovor = await Service.promjena(routeParams.id, ocjena);

    if (odgovor.greska) {
        prikaziError(Array.isArray(odgovor.poruka) ? odgovor.poruka : [odgovor.poruka]);
        return;
    }

    alert("Ocjena je uspješno promijenjena!");
    navigate(RouteNames.OCJENA_PREGLED);
  }

  function obradiSubmit(e) {
    e.preventDefault();
    const podaci = new FormData(e.target);

    if (!ucenikId || !predmetId) {
      prikaziError(['Morate odabrati učenika i predmet.']);
      return;
    }

    promjena({
      ucenikId: parseInt(ucenikId),
      predmetId: parseInt(predmetId),
      vrijednostOcjene: parseInt(podaci.get('vrijednostOcjene')), 
      datum: podaci.get('datum')
    });
  }

  return (
    <>
      <h2>Ocjena promjena</h2>
      <Row>
        <Col sm={12} lg={6} md={6}>
          <Form onSubmit={obradiSubmit}>
            <Form.Group className='mb-3' controlId="ucenikId">
              <Form.Label>Učenik</Form.Label>
              <Form.Select 
                value={ucenikId}
                onChange={(e) => {setUcenikId(e.target.value)}}
              >
                <option value="">Odaberite učenika</option>
                {ucenici.map((s, index) => (
                  <option key={index} value={s.id}>
                    {s.naziv}
                  </option>
                ))}
              </Form.Select>
            </Form.Group>

            <Form.Group className='mb-3' controlId="predmetId">
              <Form.Label>Predmet</Form.Label>
              <Form.Select 
                value={predmetId}
                onChange={(e) => {setPredmetId(e.target.value)}}
              >
                <option value="">Odaberite predmet</option>
                {predmeti.map((s, index) => (
                  <option key={index} value={s.id}>
                    {s.naziv}
                  </option>
                ))}
              </Form.Select>
            </Form.Group>

            <Form.Group controlId="VrijednostOcjena">
              <Form.Label>Vrijednost Ocjene</Form.Label>
              <Form.Control 
                type="number" 
                name="vrijednostOcjene" 
                required 
                min="1" // Dodajte minimalnu vrijednost
                defaultValue={ocjena.vrijednostOcjene} 
              />
            </Form.Group>

            <Form.Group controlId="datum">
              <Form.Label>Datum</Form.Label>
              <Form.Control 
                type="date" 
                name="datum" 
                required 
                defaultValue={ocjena.datum?.split('T')[0]} 
              />
            </Form.Group>

            <hr />
            <Row>
              <Col xs={6} sm={6} md={3} lg={6}>
                <Link to={RouteNames.OCJENA_PREGLED} className="btn btn-danger siroko">
                  Odustani
                </Link>
              </Col>
              <Col xs={6} sm={6} md={9} lg={6}>
                <Button variant="primary" type="submit" className="siroko">
                  Promjeni ocjenu
                </Button>
              </Col>
            </Row>
          </Form>
        </Col>
      </Row>
    </>
  );
}
