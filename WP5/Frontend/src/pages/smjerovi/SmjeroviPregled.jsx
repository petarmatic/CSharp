import { useEffect } from "react"
import SmjerService from "../../services/SmjerService"


export default function SmjeroviPregled(){

    async function dohvatiSmjerove(){
        await SmjerService.get();
    } 

    // Ovaj hook (kuka) se izvodi dolaskom na stranicu Smjerovi
    useEffect(()=>{
       dohvatiSmjerove();
    },[])




    return(
        <>
        Ovdje će doći pregled smjerova
        </>
    )
}