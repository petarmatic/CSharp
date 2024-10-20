import { useEffect, useState } from "react";
import {Link, useNavigate, useParams } from "react-router-dom";
import PredmetService from "../../services/PredmetService";
import { RouteNames } from "../../constants";
import { Button, Col, Form, Row } from "react-bootstrap";



export default function PredmetiPromjena(){
    const navigate= useNavigate();
    const routeParams= useParams();
    const [predmet,setPredmet]=useState({});

    async function dohvatiPredmet() {
        const odgovor=await PredmetService.getById(routeParams.id);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setPredmet(odgovor.poruka);
    }
    useEffect(()=>{
        dohvatiPredmet();
    },[]);


    async function promjena(e) {
        const odgovor=await PredmetService.promjena(routeParams.id,e);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.PREDMET_PREGLED);
        
    }

    function obradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        promjena({
            naziv:podaci.get('naziv')
    });
}

return(
    <>

    Promjena predmeta
    <Form onSubmit={obradiSubmit}>

    <Form.Group controlId="naziv">
         <Form.Label>Naziv</Form.Label>
         <Form.Control type="text" name="naziv" required defaultValue={predmet.naziv}/>
    </Form.Group>

    <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RouteNames.PREDMET_PREGLED}
                    className="btn btn-danger siroko">
                    Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Promjeni predmet
                    </Button>
                    </Col>
                </Row>


    </Form>
    </>
)



}