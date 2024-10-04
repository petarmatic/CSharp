import SmjerService from "../../services/SmjerService"
import { Button, Row, Col, Form } from "react-bootstrap";
import moment from "moment";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import { useEffect, useState } from "react";


export default function SmjeroviPromjena(){

    const [smjer,setSmjer] = useState({})
    const navigate = useNavigate()
    const routeParams = useParams()

    async function dohvatiSmjer(){
        const odgovor = await SmjerService.getBySifra(routeParams.sifra);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        //debugger; // ovo radi u Chrome inspect (ali i ostali preglednici)
        let s = odgovor.poruka
        s.izvodiSeOd = moment.utc(s.izvodiSeOd).format('yyyy-MM-DD')
        setSmjer(s)
    } 

    useEffect(()=>{
        dohvatiSmjer();
     },[])

     async function promjena(smjer) {
        //console.log(smjer)
        //console.log(JSON.stringify(smjer))
        const odgovor = await SmjerService.promjena(routeParams.sifra,smjer)
        if(odgovor.greska){
            alert(odgovor.poruka)
            return;
        }
        navigate(RouteNames.SMJER_PREGLED)
    }

    function obradiSubmit(e){ // e je event
        e.preventDefault(); // nemoj odraditi zahtjev na server
        let podaci = new FormData(e.target)
        //console.log(podaci.get('naziv'))
        promjena({
            naziv: podaci.get('naziv'),
            trajanje: parseInt(podaci.get('trajanje')),
            cijena: parseFloat(podaci.get('cijena')),
            izvodiSeOd: moment.utc(podaci.get('izvodiSeOd')),
            vaucer: podaci.get('vaucer')=='on' ? true : false 
        })
    }

    return(
        <>
        Promjena smjera
        <Form onSubmit={obradiSubmit}>

            <Form.Group controlId="naziv">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" required
                defaultValue={smjer.naziv} />
            </Form.Group>

            <Form.Group controlId="trajanje">
                <Form.Label>Trajanje</Form.Label>
                <Form.Control type="number" min={10} max={500} name="trajanje" required defaultValue={smjer.trajanje}/>
            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="number" step={0.01} name="cijena" defaultValue={smjer.cijena}/>
            </Form.Group>

            <Form.Group controlId="izvodiSeOd">
                <Form.Label>Izvodi se od</Form.Label>
                <Form.Control type="date" step={0.01} name="izvodiSeOd" defaultValue={smjer.izvodiSeOd}/>
            </Form.Group>

            <Form.Group controlId="vaucer">
                <Form.Check label="Vaučer" name="vaucer" defaultChecked={smjer.vaucer} />
            </Form.Group>

        <Row className="akcije">
            <Col xs={6} sm={12} md={3} lg={6} xl={6} xxl={6}>
            <Link to={RouteNames.SMJER_PREGLED} 
            className="btn btn-danger siroko">Odustani</Link>
            </Col>
            <Col xs={6} sm={12} md={9} lg={6} xl={6} xxl={6}>
            <Button variant="success"
            type="submit"
            className="siroko">Promjeni smjer</Button>
            </Col>
        </Row>
        </Form>
        </>
    )
}