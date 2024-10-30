import { HttpService } from "./HttpService"

async function get() {
    return HttpService.get('/Obavijest')
        .then((odgovor) => odgovor.data)
        .catch((e) => {
            console.error(e);
            return { greska: true, poruka: 'Greška prilikom dohvaćanja obavijesti.' };
        });
}

async function getById(id) {
    return HttpService.get(`/Obavijest/${id}`)
        .then((odgovor) => ({ greska: false, poruka: odgovor.data }))
        .catch(() => ({ greska: true, poruka: 'Ne postoji Obavijest!' }));
}

async function obrisi(id) {
    return HttpService.delete(`/Obavijest/${id}`)
        .then((odgovor) => ({ greska: false, poruka: odgovor.data }))
        .catch((e) => {
            console.error(e);
            return { greska: true, poruka: 'Obavijest se ne može obrisati!' };
        });
}

async function dodaj(obavijest) {
    return HttpService.post('/Obavijest', obavijest)
        .then((odgovor) => ({ greska: false, poruka: odgovor.data }))
        .catch((e) => {
            let poruke = '';
            if (e.response && e.response.data.errors) {
                for (const kljuc in e.response.data.errors) {
                    poruke += `${kljuc}: ${e.response.data.errors[kljuc][0]}, `;
                }
            }
            return { greska: true, poruka: poruke || 'Obavijest se ne može dodati!' };
        });
}

async function promjena(id, obavijest) {
    return HttpService.put(`/Obavijest/${id}`, obavijest)
      .then((odgovor) => {
        console.log("Odgovor iz API-a:", odgovor);
        return { greska: false, poruka: odgovor.data };
      })
      .catch((e) => {
        let poruke = '';
        if (e.response && e.response.data.errors) {
          for (const kljuc in e.response.data.errors) {
            poruke += `${kljuc}: ${e.response.data.errors[kljuc][0]}, `;
          }
        }
        return { greska: true, poruka: poruke || 'Obavijest se ne može promijeniti!' };
      });
  }

async function getPredmeti(id) {
    return HttpService.get(`/Obavijest/Predmeti/${id}`)
        .then((odgovor) => ({ greska: false, poruka: odgovor.data }))
        .catch(() => ({ greska: true, poruka: 'Problem kod dohvaćanja predmeta.' }));
}

async function dodajPredmet(obavijest, predmet) {
    return HttpService.post(`/Obavijest/${obavijest}/dodaj/${predmet}`)
        .then((odgovor) => ({ greska: false, poruka: odgovor.data }))
        .catch(() => ({ greska: true, poruka: 'Predmet se ne može dodati na obavijest.' }));
}

async function obrisiPredmet(obavijest, predmet) {
    return HttpService.delete(`/Obavijest/${obavijest}/obrisi/${predmet}`)
        .then((odgovor) => ({ greska: false, poruka: odgovor.data }))
        .catch(() => ({ greska: true, poruka: 'Predmet se ne može obrisati iz obavijesti.' }));
}

export default {
    get,
    getById,
    obrisi,
    dodaj,
    promjena,
    getPredmeti,
    dodajPredmet,
    obrisiPredmet,
};
