



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


export default{

    get
    
}