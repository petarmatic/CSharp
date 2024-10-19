import { useNavigate } from "react-router-dom";
import PredmetService from "../../services/PredmetService";
import { RouteNames } from "../../constants";



export default function PredmetiDodaj(){

    const navigate = useNavigate();

    async function dodaj(e) {
        const odgovor= await PredmetService.dodaj(e);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.UCENIK_PREGLED);
        
    }

    function obradiSubmit(e){ 
        e.preventDefault();

        const podaci = new FormData(e.target);

        dodaj({
            naziv:podaci.get('naziv')
        });
    }


    return(
        <>
        Dodavanje novog Predmeta
        <Form onSubmit={obradiSubmit}>
            <Form.Group controlId="naziv">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" required />
            </Form.Group>
        
            <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RouteNames.PREDMET_PREGLEDPREGLED}
                    className="btn btn-danger siroko">
                    Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Dodaj novi predmet
                    </Button>
                    </Col>
                </Row>


        </Form>

        </>

    )


}