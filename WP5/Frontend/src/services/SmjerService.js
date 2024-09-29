import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/Smjer')
    .then((odgovor)=>{
        console.log(odgovor.data)
        console.table(odgovor.data)
    })
    .catch((e)=>console.log(e))
}


export default {
    get
}