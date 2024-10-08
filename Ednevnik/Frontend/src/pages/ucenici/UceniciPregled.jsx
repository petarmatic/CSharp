import { useEffect, useState } from 'react';
import Table from 'react-bootstrap/Table';
import UcenikService from '../../services/UcenikService';





export default function UceniciPregled() {
  const[ucenici,setUcenici]=useState();

async function dohvatiUcenike() {
    const odgovor=await UcenikService.get();
    if(odgovor.greska){
      alert(odgovor.poruka)
      return
    }
    setUcenici(odgovor.poruka)
    
}
useEffect(() => {
    dohvatiUcenike();
  }, []);

  return (
    <>
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>ID</th>
            <th>Ime</th>
            <th>Prezime</th>
            <th>OIB</th>
            <th>Školska godina</th>
          </tr>
        </thead>
        <tbody>
          {ucenici.map((e,index)=>
           <tr key={index}>
           <td>{e.id}</td> 
           <td>{e.ime}</td>
           <td>{e.prezime}</td>
           <td>{e.oib}</td>
           <td>{e.skolaskaGodina}

           </td>
         </tr>
          )}
        </tbody>
        
      </Table>
      
    </>
  )
}
