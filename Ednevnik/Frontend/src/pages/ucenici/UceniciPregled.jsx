import {  Button, Table } from "react-bootstrap";
import UcenikService from "../../services/UcenikService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom"; 
import { RouteNames } from "../../constants";




export default function UceniciPregled() {
  const navigate =useNavigate();

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


  function obrisi(id){
    if(!confirm('Sigurno obrisati')){
        return;
    }
    brisanjeUcenika(id)
}

async function brisanjeUcenika(id) {
    const odgovor=await UcenikService.brisanje(id);
    if(odgovor.greska){
        alert(odgovor.poruka)
        return
    }
    dohvatiUcenike();
}

return (
  <>
    <Link to={RouteNames.UCENIK_DODAJ} className="btn btn-success">Dodaj novog učenika</Link>
    <Table striped bordered hover responsive>
      <thead>
        <tr>
          <th>ID</th>
          <th>Ime</th>
          <th>Prezime</th>
          <th>OIB</th>
          <th>Školska godina</th>
          <th>Akcije</th>
        </tr>
      </thead>
      <tbody>
        {ucenici && ucenici.map((ucenik, index) => (
          <tr key={index}>
            <td>{ucenik.id}</td>
            <td>{ucenik.ime}</td>
            <td>{ucenik.prezime}</td>
            <td>{ucenik.oib}</td>
            <td>{ucenik.skolskaGodina}</td>
            <td>
              <Button variant="danger" onClick={() => obrisi(ucenik.id)}>Obriši</Button>
              &nbsp;&nbsp;&nbsp;
              <Button onClick={() => navigate(`/ucenici/${ucenik.id}`)}>Promjena</Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  </>
);
}