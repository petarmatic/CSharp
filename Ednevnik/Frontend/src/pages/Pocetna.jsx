import { useContext } from 'react';
import { AuthContext } from '../components/AuthContext';
import Container from 'react-bootstrap/Container';

export default function Pocetna() {
    const { isLoggedIn } = useContext(AuthContext);

    return (
        <Container className="pocetna-container">
            <h1>Dobrodošli!</h1>
            {isLoggedIn ? ( // Provjerite da li je korisnik prijavljen
                <p>Za daljnji rad, izaberite opciju iz izbornika.</p> // Prikazivanje poruke za daljnji rad
            ) : (
                <p>Prvo se prijavite.</p> // Poruka kada korisnik nije prijavljen
            )}
        </Container>
    );
}
