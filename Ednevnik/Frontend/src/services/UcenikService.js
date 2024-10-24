import { HttpService } from "./HttpService"

async function get(){
    return await HttpService.get('/Ucenik')
    .then((odgovor)=>{
        //console.log(odgovor.data)
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        //console.log(e)
        return {greska: true, poruka: 'Problem kod dohvaćanja učenika'}   
    })
   
}

async function dodaj(ucenik) {
    return await HttpService.post('/Ucenik', ucenik)
    .then((odgovor)=>{
        return{greska: false, poruka:odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + '\n';
                }
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Ucenik se ne može dodati!'}
        }
    })
    
}

async function brisanje(id){
    return await HttpService.delete('/Ucenik/' + id)
    .then(()=>{
        return{greska:false,poruka:'Obrisano'}
    })
    .catch(()=>{
        return{greska:true, poruka:'Problem kod brisanja učenika'}
    })    
}

async function getById(id) {
    return await HttpService.get('/Ucenik/'+id)
    .then((odgovor)=>{
        return{greska:false,poruka:odgovor.data}
    })
    .catch((e)=>{
        return{greska:true,poruka:'Problem kod dohvaćanja učenika s id'+id}
    })
}

async function promjena(id,ucenik) {
    return await HttpService.put('/Ucenik/'+id,ucenik)
    .then((odgovor)=>{
        return{greska:false,poruka:odgovor.data}
    })
    .catch((e)=>{
        switch(e.status){
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke +=kljuc + ':' + e.response.data.errors[kljuc][0] + '\n';
                }
                console.log(poruke)
                return{greska:true, poruka:poruke}
            default:
                return {greska:true, poruka:'Učenik se ne može promjeniti!'}
        }
    })
}


export default{
    get,
    dodaj,
    brisanje,
    getById,
    promjena
}