import {  Table } from "react-bootstrap";
import UcenikService from "../../services/UcenikService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom"; 
import { RouteNames } from "../../constants";




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
      <Link to={RouteNames.UCENIK_NOVI}
        className="btn btn-success ">Dodaj novog učenika</Link>
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
          {ucenici&&ucenici.map((ucenik,index)=>
           <tr key={index}>
              <td>{ucenik.id}</td> 
              <td>{ucenik.ime}</td>
              <td>{ucenik.prezime}</td>
              <td>{ucenik.oib}</td>
              <td>{ucenik.skolska_godina}

              </td>
         </tr>
          )}
        </tbody>
        
      </Table>
      
    </>
  )
}
