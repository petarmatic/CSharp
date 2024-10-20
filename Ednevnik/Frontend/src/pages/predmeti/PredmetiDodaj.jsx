import { useNavigate } from "react-router-dom";
import PredmetService from "../../services/PredmetService";
import { RouteNames } from "../../constants";
import { Link } from "react-router-dom";
import { Button, Col, Form, Row } from "react-bootstrap"; 

export default function PredmetiDodaj() {
    const navigate = useNavigate();

    async function dodaj(predmet) { 
        const odgovor = await PredmetService.dodaj(predmet);
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.PREDMET_PREGLED);
    }

    function obradiSubmit(e) { 
        e.preventDefault();
        const podaci = new FormData(e.target);
        dodaj({
            naziv: podaci.get('naziv') 
        });
    }

    return (
        <>
            <h2>Dodavanje novog Predmeta</h2>
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required />
                </Form.Group>
        
                <hr />
                <Row>
                    <Col xs={6}>
                        <Link to={RouteNames.PREDMET_PREGLED} className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6}>
                        <Button variant="primary" type="submit" className="siroko">
                            Dodaj novi predmet
                        </Button>
                    </Col>
                </Row>
            </Form>
        </>
    );
}
