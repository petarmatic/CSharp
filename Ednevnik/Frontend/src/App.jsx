import 'bootstrap/dist/css/bootstrap.min.css'
import Container from 'react-bootstrap/Container';
import './App.css'
import NavBarEdnevnik from './components/NavBarEdnevnik';

function App() {
  

  return (
    <>
       <Container>
          <NavBarEdnevnik/>
      <hr/>
      &copy; Ednevnik
    </Container>
    </>
  )
}

export default App
