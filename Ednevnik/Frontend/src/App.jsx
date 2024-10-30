import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import './App.css';
import NavBarEdnevnik from './components/NavBarEdnevnik';
import { Route, Routes } from 'react-router-dom';
import { RouteNames } from './constants';
import Pocetna from './pages/Pocetna';
import UceniciPregled from './pages/ucenici/UceniciPregled';
import UceniciDodaj from './pages/ucenici/UceniciDodaj'; 
import UceniciPromjena from './pages/ucenici/UceniciPromjena';
import PredmetiPregled from './pages/predmeti/PredmetiPregled';
import PredmetiDodaj from './pages/predmeti/PredmetiDodaj';
import PredmetiPromjena from './pages/predmeti/PredmetiPromjena';
import ObavijestiPregled from './pages/obavijesti/ObavijestiPregled';
import ObavijestiDodaj from './pages/obavijesti/ObavijestiDodaj';
import ObavijestiPromjena from './pages/obavijesti/ObavijestiPromjena';
import OcjenePregled from './pages/ocjene/OcjenePregled';
import OcjeneDodaj from './pages/ocjene/OcjeneDodaj';
import OcjenePromjena from './pages/ocjene/OcjenePromjena';


import useError from "./hooks/useError"
import ErrorModal from "./components/ErrorModal"

function App() {

  const { errors, prikaziErrorModal, sakrijError } = useError();
  return (
    <>
    <ErrorModal show={prikaziErrorModal} errors={errors} onHide={sakrijError} />
      <Container>
        <NavBarEdnevnik />
        
        <Routes>
          <Route path={RouteNames.HOME} element={<Pocetna />} />

          <Route path={RouteNames.UCENIK_PREGLED} element={<UceniciPregled />} />
          <Route path={RouteNames.UCENIK_DODAJ} element={<UceniciDodaj />} /> 
          <Route path={RouteNames.UCENIK_PROMJENA} element={<UceniciPromjena />} />

          <Route path={RouteNames.PREDMET_PREGLED} element={<PredmetiPregled />} />
          <Route path={RouteNames.PREDMET_DODAJ} element={<PredmetiDodaj />} />
          <Route path={RouteNames.PREDMET_PROMJENA} element={<PredmetiPromjena />} />

          <Route path={RouteNames.OBAVIJEST_PREGLED} element={<ObavijestiPregled />} />
          <Route path={RouteNames.OBAVIJEST_DODAJ} element={<ObavijestiDodaj />} />
          <Route path={RouteNames.OBAVIJEST_PROMJENA} element={<ObavijestiPromjena />} />

          <Route path={RouteNames.OCJENA_PREGLED} element={<OcjenePregled />} />
          <Route path={RouteNames.OCJENA_DODAJ} element={<OcjeneDodaj />} />
          <Route path={RouteNames.OCJENA_PROMJENA} element={<OcjenePromjena />} />
        
          
    
        </Routes>
        
        <hr />
        &copy; Ednevnik
      </Container>
    </>
  );
}

export default App;
