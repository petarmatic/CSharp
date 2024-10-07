import { useEffect, useState } from 'react';
import Table from 'react-bootstrap/Table';
import UcenikService from ".../.../service/UcenikService"


export default function UceniciPregled() {
const[ucenici,setUcenici]=useState();

async function dohvatiUcenike() {
    await UcenikService.get().then((odgovor) => {setUcenici(odgovor);}).catch((e)=>{console.log(e)});
    
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
  );
}
