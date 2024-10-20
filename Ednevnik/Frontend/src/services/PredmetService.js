import { HttpService } from "./HttpService"


async function get(){
    return await HttpService.get('/Predmet')
    .then((odgovor)=>{
        //console.log(odgovor.data)
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        console.log(e)
        return {greska: true, poruka: 'Problem kod dohvaćanja predmeta'}   
    })
}

async function getById(id) {
    return await HttpService.get('/Predmet/' +id)
    .then((odgovor)=>{
        return{greska:false,poruka:odgovor.data}
    })
    .catch(()=>{
        return{greska:true,poruka:'Ne postoji taj predmet'}
    })
    
}

async function obrisi(id) {

     return await HttpService.delete('/Predmet/' +id)
    .then((odgovor)=>{
        return{greska:false,poruka:odgovor.data}
    })
    .catch(()=>{
        return{greska:true,poruka:'Predmet se ne može obrisati'}
    })
}

async function dodaj(Predmet) {
    return await HttpService.post('/Predmet/',Predmet)
    .then((odgovor)=>{
        return{greska:false,poruka:odgovor.data}
    })
    .catch((e)=>{
        switch(e.status){
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + '\n';
                }
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Predmet se ne može dodati!'}
        }
})
    
}

async function promjena(id,predmet) {
    return await HttpService.put('/Predmet/'+id,predmet)
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
                return {greska:true, poruka:'Predmet se ne može promjeniti!'}
        }
    })
}


export default{

    get,
    getById,
    obrisi,
    dodaj,
    promjena
    
}