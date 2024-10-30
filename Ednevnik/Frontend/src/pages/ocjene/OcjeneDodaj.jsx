import { useEffect, useState } from "react";
import PredmetService from "../../services/PredmetService";
import UcenikService from '../../services/UcenikService'; 
import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import Service from '../../services/OcjenaService';
import { RouteNames } from '../../constants';

export default function OcjeneDodaj() {
    const navigate = useNavigate();
    const [predmeti, setPredmeti] = useState([]);
    const [predmetId, setPredmetId] = useState(0);
    const [ucenici, setUcenici] = useState([]);
    const [ucenikId, setUcenikId] = useState(0);

    async function dohvatiPredmete() {
        try {
            const odgovor = await PredmetService.get();
            console.log("Dohvaćeni predmeti:", odgovor.poruka); 
            setPredmeti(odgovor.poruka);
            setPredmetId(odgovor.poruka[0]?.id || 0);
        } catch (e) {
            console.error("Greška prilikom dohvaćanja predmeta:", e);
        }
    }

    async function dohvatiUcenike() {
        try {
            const odgovor = await UcenikService.get();
            console.log("Dohvaćeni učenici:", odgovor.poruka); 
            setUcenici(odgovor.poruka);
            setUcenikId(odgovor.poruka[0]?.id || 0);
        } catch (e) {
            console.error("Greška prilikom dohvaćanja učenika:", e);
        }
    }

    useEffect(() => {
        dohvatiPredmete();
        dohvatiUcenike();
    }, []);

    async function dodaj(ocjena) {
        console.log("Podaci za dodavanje:", ocjena); 
        const odgovor = await Service.dodaj(ocjena);
        console.log("Odgovor od servisa:", odgovor); 
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.OCJENE_PREGLED);
    }

    function obradiSubmit(e) {
        e.preventDefault();
        const podaci = new FormData(e.target);
        const ocjena = {
            ucenikId: parseInt(ucenikId),
            predmetId: parseInt(predmetId),
            vrijednostOcjene: parseInt(podaci.get('VrijednostOcjena')), 
            datum: podaci.get('datum'),
        };
        console.log("Podaci iz forme:", ocjena); 
        dodaj(ocjena);
    }
    
    return (
        <Container>
            <h2>Dodavanje nove ocjene</h2>
            <Form onSubmit={obradiSubmit}>

                <Form.Group className='mb-3' controlId='ucenik'>
                    <Form.Label>Učenik</Form.Label>
                    <Form.Select onChange={(e) => { setUcenikId(e.target.value) }}>
                        {ucenici && ucenici.map((s, index) => (
                            <option key={index} value={s.id}>
                                {s.ime}
                            </option>
                        ))}
                    </Form.Select>
                </Form.Group>

                <Form.Group className='mb-3' controlId='predmet'>
                    <Form.Label>Predmet</Form.Label>
                    <Form.Select onChange={(e) => { setPredmetId(e.target.value) }}>
                        {predmeti && predmeti.map((s, index) => (
                            <option key={index} value={s.id}>
                                {s.naziv}
                            </option>
                        ))}
                    </Form.Select>
                </Form.Group>

                <Form.Group controlId="VrijednostOcjena">
                    <Form.Label>Vrijednost Ocjene</Form.Label>
                    <Form.Control type="number" name="VrijednostOcjena" required />
                </Form.Group>

                <Form.Group controlId="datum">
                    <Form.Label>Datum</Form.Label>
                    <Form.Control type="date" name="datum" required />
                </Form.Group>

                <hr />
                <Row>
                    <Col xs={6}>
                        <Link to={RouteNames.OCJENA_PREGLED} className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6}>
                        <Button variant="primary" type="submit" className="siroko">
                            Dodaj novu ocjenu
                        </Button>
                    </Col>
                </Row>
            </Form>
        </Container>
    );
}
