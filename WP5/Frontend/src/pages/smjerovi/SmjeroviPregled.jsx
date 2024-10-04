import { useEffect, useState } from "react"
import SmjerService from "../../services/SmjerService"
import { Table } from "react-bootstrap";


export default function SmjeroviPregled(){

    const[smjerovi,SetSmjerovi] = useState();

    async function dohvatiSmjerove(){
       const odgovor= await SmjerService.get();
       if(odgovor.greska){
        alert(odgovor.poruka)
        return
       }
       SetSmjerovi(odgovor.poruka)
    } 

    // Ovaj hook (kuka) se izvodi dolaskom na stranicu Smjerovi
    useEffect(()=>{
       dohvatiSmjerove();
    },[])

    function formatirajDatum(datum){
        if(datum==null){
            return 'Nije definirano';
        }
        return moment.utc(datum).format('DD. MM. YYYY.')
    }

    function vaucer(v){
        if(v==null) return 'gray'
        if(v) return 'green'
        return 'red'
    }
    function obrisi(sifra){
        if(!confirm('Sigurno obrisati')){
            return;
        }
        brisanjeSmjera(sifra)
    }
    async function brisanjeSmjera(sifra) {
        
        const odgovor = await SmjerService.brisanje(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        dohvatiSmjerove();
    }

    return(
        <>
        <Table striped bordered hover responsive>
            <thead>
                <tr>
                <th>Naziv</th>
                    <th>Trajanje</th>
                    <th>Cijena</th>
                    <th>Izvodi se od</th>
                    <th>Vaučer</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {smjerovi&&smjerovi.map((smjer,index)=>(
                    <tr key={index}>
                        <td>
                            {smjer.naziv}
                        </td>
                        <td className={smjer.trajanje==null ? 'sredina' : 'desno'}>
                            {smjer.trajanje== null ? 'Nije definirano' : smjer.trajanje}
                        </td>
                        <td className={smjer.cijena==null ? 'sredina' : 'desno'}>
                        {smjer.cijena==null ? 'Nije definirano' : 
                        <NumericFormat 
                        value={smjer.cijena}
                        displayType={'text'}
                        thousandSeparator='.'
                        decimalSeparator=','
                        prefix={'€'}
                        decimalScale={2}
                        fixedDecimalScale
                        />
                        }
                        </td>
                        <td className="sredina">
                            {formatirajDatum(smjer.izvodiSeOd)}
                        </td>
                        <td className="sredina">
                            <GrValidate 
                            size={30}
                            color={vaucer(smjer.vaucer)}
                            />
                        </td>
                        <td>
                        <Button
                            variant="danger"
                            onClick={()=>obrisi(smjer.sifra)}
                            >
                                Obriši
                                </Button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        
        </>
    )
}