import { useEffect, useState } from "react";
import PredmetService from "../../services/PredmetService";
import { Button, Col, Container, Form, Row } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import Service from '../../services/ObavijestService';
import { RouteNames } from '../../constants';

export default function ObavijestiDodaj() {
    const navigate = useNavigate();
    const [predmeti, setPredmeti] = useState([]);
    const [predmetId, setPredmetId] = useState(0);

    async function dohvatiPredmete() {
        const odgovor = await PredmetService.get();
        console.log("Dohvaćeni predmeti:", odgovor.poruka); 
        setPredmeti(odgovor.poruka);
        setPredmetId(odgovor.poruka[0]?.id || 0);
    }

    useEffect(() => {
        dohvatiPredmete();
    }, []);

    async function dodaj(obavijest) {
        console.log("Podaci za dodavanje:", obavijest); 
        const odgovor = await Service.dodaj(obavijest);
        console.log("Odgovor od servisa:", odgovor); 
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.OBAVIJEST_PREGLED);
    }

    function obradiSubmit(e) {
        e.preventDefault();
        const podaci = new FormData(e.target);
        const obavijest = {
            tekst: podaci.get('tekst'),
            datum: podaci.get('datum'),
            predmetId: parseInt(predmetId),
        };
        console.log("Podaci iz forme:", obavijest); 
        dodaj(obavijest);
    }

    return (
        <>
            Dodavanje nove obavijesti

            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="tekst">
                    <Form.Label>Tekst</Form.Label>
                    <Form.Control type="text" name="tekst" required />
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

                <Form.Group controlId="datum">
                    <Form.Label>Datum</Form.Label>
                    <Form.Control type="date" name="datum" required />
                </Form.Group>

                <hr />
                <Row>
                    <Col xs={6}>
                        <Link to={RouteNames.OBAVIJEST_PREGLED} className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6}>
                        <Button variant="primary" type="submit" className="siroko">
                            Dodaj novu obavijest
                        </Button>
                    </Col>
                </Row>
            </Form>
        </>
    );
}
