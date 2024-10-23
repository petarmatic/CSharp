import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom';
import { RouteNames } from '../constants';
import Container from 'react-bootstrap/Container';

export default function NavBarEdnevnik() {
  const navigate = useNavigate();

  return (
    <> 
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand onClick={() => navigate(RouteNames.HOME)} className="ruka">
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
                  Učenici
                </NavDropdown.Item>
                <NavDropdown.Item onClick={()=>navigate(RouteNames.PREDMET_PREGLED)}>
                  Predmeti
                </NavDropdown.Item>

                <NavDropdown.Item onClick={()=>navigate(RouteNames.OBAVIJEST_PREGLED)}>
                  Obavijesti
                </NavDropdown.Item>

                <NavDropdown.Item onClick={()=>navigate(RouteNames.OCJENA_PREGLED)}>
                  Ocjene
                </NavDropdown.Item>

              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
}
