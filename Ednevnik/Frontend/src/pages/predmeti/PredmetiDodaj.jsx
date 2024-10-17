import { Form, useNavigate } from "react-router-dom";
import PredmetService from "../../services/PredmetService";
import { RouteNames } from "../../constants";




export default function PredmetiDodaj(){


    const navigate= useNavigate();

    async function dodaj(predmet) {
        const odgovor=await PredmetService.dodaj(predmet)   
        if (odgovor.greska){
            alert (odgovor.poruka)
            return;
        }
        navigate (RouteNames.PREDMET_PREGLED)
        
    }

    function obradiSubmit(e){
        e.preventDefault();
        let podaci= new FormData(e.target)
            dodaj({
                naziv:podaci.get('naziv')
            })
        
    }

    return(
        <>
            Dodavanje predmeta
            <Form onSubmit={obradiSubmit}></Form>
            <Form.Group controldId='naziv'>
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" required />
            </Form.Group>
        
        
        
        </>

    )
}