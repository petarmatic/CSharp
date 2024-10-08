import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom'; // Dodaj useNavigate
import { RouteNames } from '../constants';
import Container from 'react-bootstrap/Container';

export default function NavBarEdnevnik() {
  const navigate = useNavigate(); // Inicijaliziraj navigate

  return (
    <> 
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="#home">Ednevnik</Navbar.Brand>
          <Navbar.Brand className='ruka' onClick={() => navigate(RouteNames.HOME)}>
            Ednevnik
          </Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="https://pmatic-001-site1.ctempurl.com/swagger/index.html">
                Swagger
              </Nav.Link>
              <NavDropdown title="Učenici" id="basic-nav-dropdown">
                <NavDropdown.Item onClick={() => navigate(RouteNames.UCENIK_PREGLED)}>
                  Pregled učenika
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
}
