import { HttpService } from "./HttpService"



async function get(){
    return await HttpService.get('/Predmet')
    .then((odgovor)=>{
        
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        
        return {greska: true, poruka: 'Problem kod dohvaćanja predmeta'}   
    })
}


export default{
    get
    
}