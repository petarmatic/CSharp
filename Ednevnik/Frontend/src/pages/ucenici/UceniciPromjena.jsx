import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import UcenikService from "../../services/UcenikService";
import { RouteNames } from "../../constants";
import { Button, Col, Form, Row } from "react-bootstrap";


export default function UceniciPromjena(){

    const [ucenik, setUcenik] = useState({}); // Prazan objekt kao inicijalna vrijednost
    const navigate = useNavigate();
    const routeParams = useParams();

    async function dohvatiUcenika() {
        const odgovor = await UcenikService.getById(routeParams.id);
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        setUcenik(odgovor.poruka); // Postavi dohvaćene podatke u state
    }

    useEffect(() => {
        dohvatiUcenika();
    }, []);

    async function promjena(ucenik) {
        const odgovor = await UcenikService.promjena(routeParams.id, ucenik);
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.UCENIK_PREGLED);
    }

    function obradiSubmit(e) {
        e.preventDefault();
        let podaci = new FormData(e.target);
        promjena({
            ime: podaci.get('ime'), 
            prezime: podaci.get('prezime'),
            oib: podaci.get('oib'),
            skolskaGodina: podaci.get('skolskaGodina') 
        });
    }

    return (
        <>
            Promjena učenika
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                        type="text" 
                        name="ime" 
                        required 
                        defaultValue={ucenik.ime } 
                    />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                        type="text" 
                        name="prezime" 
                        required 
                        defaultValue={ucenik.prezime } 
                    />
                </Form.Group>

                <Form.Group controlId="oib">
                    <Form.Label>OIB</Form.Label>
                    <Form.Control 
                        type="text" 
                        name="oib"  
                        defaultValue={ucenik.oib } 
                    />
                </Form.Group>

                <Form.Group controlId="skolskaGodina">
                    <Form.Label>Školska godina</Form.Label>
                    <Form.Control 
                        type="text" 
                        name="skolskaGodina"  
                        defaultValue={ucenik.skolskaGodina } 
                    />
                </Form.Group>

                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                        <Link to={RouteNames.UCENIK_PREGLED}
                            className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                        <Button variant="primary" type="submit" className="siroko">
                            Promjeni učenika
                        </Button>
                    </Col>
                </Row>
            </Form>
        </>
    );
}
