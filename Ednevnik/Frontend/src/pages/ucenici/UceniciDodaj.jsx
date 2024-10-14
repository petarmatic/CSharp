import { Form, useNavigate } from "react-router-dom";
import UcenikService from "../../services/UcenikService";
import { RouteNames } from "../../constants";




export default function UceniciDodaj(){

    const navigate=useNavigate();

    async function dodaj(ucenik) {
        const odgovor= await UcenikService.dodaj(ucenik)
        if(odgovor.greska){
            alert(odgovor.poruka)
            return;
        }
        navigate(RouteNames.UCENIK_PREGLED)
    }

    function obradiSubmit(e){
        e.preventDefault();
        let podaci=new FormData(e.target)
        dodaj({
            ime:podaci.get('naziv'),
            prezime:podaci.get('prezime'),
            oib:podaci.get('oib'),
            skolskaGodina:podaci.get('skolskaGodina')

        })
    }

    return (
        <>
        Dodavanje učenika
        <Form onSubmit={obradiSubmit}>
            <Form.Group controlId="ime">
                <Form.Label>Ime</Form.Label>
                <Form.Control type="text" name="ime" required />
            </Form.Group>

            <Form.Group controlId="prezime">
                <Form.Label>Prezime</Form.Label>
                <Form.Control type="text" name="prezime" required />
            </Form.Group>

            <Form.Group controlId="oib">
                <Form.Label>OIB</Form.Label>
                <Form.Control type="text" name="oib" required />
            </Form.Group>

            <Form.Group controlId="skolskaGodina">
                <Form.Label>Školska Godina</Form.Label>
                <Form.Control type="text" name="skolskaGodina" required />
            </Form.Group>

        <Row className="akcije">
            <Col xs={6} sm={12} md={3} lg={6} xl={6} xxl={6}>
            <Link to={RouteNames.UCENIK_PREGLED} 
            className="btn btn-danger siroko">Odustani</Link>
            </Col>
            <Col xs={6} sm={12} md={9} lg={6} xl={6} xxl={6}>
            <Button variant="success"
            type="submit"
            className="siroko">Dodaj učenika</Button>
            </Col>
        </Row>    

        </Form>
        
        </>
    )





}
