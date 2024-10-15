import {  Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom"; 
import { RouteNames } from "../../constants";



export default function PredmetiPregled(){

    const navigate= useNavigate();



async function dohvatiPredmete() {
    const odgovor=await PredmetService.get();
    if(odgovor.greska){
        alert(odgovor.poruka)
        return
    }
    setPredmeti(odgovor.poruka)
}
useEffect(() =>{
    dohvatiPredmete();
},[]);

    
return(
    <>
    <Link to={RouteNames.PREDMET_NOVI}
        className="btn btn-success "> OVDJE IDE DODAJ predmet</Link>
      <Table striped bordered hover responsive></Table>
        <thead>
            <th>Naziv</th>
        </thead>

        <tbody>
            <tr></tr>
        </tbody>



      </>

)


}