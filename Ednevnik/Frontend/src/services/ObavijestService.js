import { HttpService } from "./HttpService"


async function get(){
    return await HttpService.get('/Obavijest')
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getById(id){
    return await HttpService.get('/Obavijest/' + id)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Ne postoji Obavijest!'}
    })
}

async function obrisi(id) {
    return await HttpService.delete('/Obavijest/' + id)
    .then((odgovor)=>{
        //console.log(odgovor);
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Obavijest se ne može obrisati!'}
    })
}

async function dodaj(Obavijest) {
    return await HttpService.post('/Obavijest',Obavijest)
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
                return {greska: true, poruka: 'Obavijest se ne može dodati!'}
        }
    })
}

async function promjena(id,Obavijest) {
    return await HttpService.put('/Obavijest/' + id,Obavijest)
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
                return {greska: true, poruka: 'Obavijest se ne može promjeniti!'}
        }
    })
}


async function getPredmeti(id){
    return await HttpService.get('/Obavijest/Predmeti/'+ id)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{return {greska: true, poruka: 'Problem kod dohvaćanja predmeta'}})
}

async function dodajPredmet(obavijest,predmet) {
    return await HttpService.post('/Obavijest/' + obavijest + '/dodaj/'+predmet)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Predmet se ne može dodati na obavijest'}
    })
}

async function obrisiPredmet(obavijest,predmet) {
    return await HttpService.delete('/Obavijest/' +obavijest + '/obrisi/'+predmet)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
                return {greska: true, poruka: 'Predmet se ne može obrisati iz obavijest'}
    })
}



export default{
    get,
    getById,
    obrisi,
    dodaj,
    promjena,

    getPredmeti,
    dodajPredmet,
    obrisiPredmet,

    
}