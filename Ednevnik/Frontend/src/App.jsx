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
function App() {
  return (
    <>
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

          
    
        </Routes>
        
        <hr />
        &copy; Ednevnik
      </Container>
    </>
  );
}

export default App;
