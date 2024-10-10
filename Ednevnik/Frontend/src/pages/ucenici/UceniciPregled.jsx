import {  Table } from "react-bootstrap";
import UcenikService from "../../services/UcenikService";
import { useEffect, useState } from "react";
import {  useNavigate } from "react-router-dom";





export default function UceniciPregled() {
  const[ucenici,setUcenici]=useState();

  const navigate =useNavigate();





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
          {ucenici&&ucenici.map((e,index)=>
           <tr key={index}>
           <td>{e.id}</td> 
           <td>{e.ime}</td>
           <td>{e.prezime}</td>
           <td>{e.oib}</td>
           <td>{e.skolska_godina}

           </td>
         </tr>
          )}
        </tbody>
        
      </Table>
      
    </>
  )
}
