import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import './App.css';
import NavBarEdnevnik from './components/NavBarEdnevnik';
import { Route, Routes } from 'react-router-dom';
import { RouteNames } from './constants';
import Pocetna from './pages/ucenici/Pocetna';
import UceniciPregled from './pages/ucenici/UceniciPregled';


function App() {
  return (
    <>
      <Container>
        <NavBarEdnevnik />
        
        <Routes>
          <Route path={RouteNames.HOME} element={<Pocetna/>} />
          <Route path={RouteNames.UCENIK_PREGLED} element={<UceniciPregled/>}/>
        </Routes>
        
        <hr />
        &copy; Ednevnik
      </Container>
    </>
  )
}

export default App