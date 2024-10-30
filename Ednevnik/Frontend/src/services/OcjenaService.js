import { HttpService } from "./HttpService"


async function get(){
    return await HttpService.get('/Ocjena')
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getById(id){
    return await HttpService.get('/Ocjena/' + id)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Ne postoji Ocjena!'}
    })
}

async function obrisi(id) {
    return await HttpService.delete('/Ocjena/' + id)
    .then((odgovor)=>{
        //console.log(odgovor);
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Ocjena se ne može obrisati!'}
    })
}

async function dodaj(Ocjena) {
    return await HttpService.post('/Ocjena',Ocjena)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + ', ';
                }
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Ocjena se ne može dodati!'}
        }
    })
}

async function promjena(id,Ocjena) {
    return await HttpService.put('/Ocjena/' + id,Ocjena)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': ' + e.response.data.errors[kljuc][0] + ', ';
                }
                console.log(poruke)
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Ocjena se ne može promjeniti!'}
        }
    })
}


async function getUcenici(id){
    return await HttpService.get('/Ocjena/Ucenici/'+ id)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod dohvaćanja učenika'}})
}

async function getPredmeti(id){
    return await HttpService.get('/Ocjena/Predmeti/'+ id)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod dohvaćanja predmeta'}})
}



export default{
    get,
    getById,
    obrisi,
    dodaj,
    promjena,

    getPredmeti,
    getUcenici
    
}