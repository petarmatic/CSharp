
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom';



export default function NavBarEdunova(){


  const navigate=useNavigate();
    return(
        <>
            <Navbar expand="lg" className="bg-body-tertiary">
              
        <Navbar.Brand href="#home">React-Bootstrap</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="http://pmatic-001-site1.ctempurl.com/swagger/index.html" target ='_blank'>Swagger</Nav.Link>
            <NavDropdown title="Programi" id="basic-nav-dropdown">
              <NavDropdown.Item onClick={()=>navigate(RoutesNames.SMJER_PREGLED)}></NavDropdown.Item>
              <NavDropdown.Item href="#action/3.2">
                Polaznici
              </NavDropdown.Item>
              <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
              
             
               
              
            </NavDropdown>
          </Nav>
          </Navbar.Collapse>
          </Navbar>
        </>
    )
}
