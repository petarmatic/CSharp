import { createContext, useEffect, useState } from 'react';
import { logInService } from '../services/AuthService';
import { useNavigate } from 'react-router-dom';
import { RouteNames } from '../constants';
import useLoading from '../hooks/useLoading';

export const AuthContext = createContext();

export function AuthProvider({ children }) {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [authToken, setAuthToken] = useState('');
  const [welcomeMessage, setWelcomeMessage] = useState(''); // Nova poruka dobrodošlice
  const { showLoading, hideLoading } = useLoading();

  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem('Bearer');

    if (token) {
      setAuthToken(token);
      setIsLoggedIn(true);
      setWelcomeMessage('Dobrodošli! Izaberite neku opciju iz izbornika.'); // Postavi poruku dobrodošlice
    } else {
      navigate(RouteNames.HOME);
    }
  }, []);

  async function login(userData) {
    showLoading();
    const odgovor = await logInService(userData);
    hideLoading();
    
    if (!odgovor.greska) {
      localStorage.setItem('Bearer', odgovor.poruka);
      setAuthToken(odgovor.poruka);
      setIsLoggedIn(true);
      setWelcomeMessage('Dobrodošli! Izaberite neku opciju iz izbornika.'); // Postavi poruku nakon prijave
      return true; // Vraćanje true ako je login uspješan
    } else {
      prikaziError(odgovor.poruka);
      localStorage.setItem('Bearer', '');
      setAuthToken('');
      setIsLoggedIn(false);
      setWelcomeMessage(''); // Očisti poruku dobrodošlice ako dođe do greške
      return false; // Vraćanje false ako login nije uspješan
    }
  }

  function logout() {
    localStorage.setItem('Bearer', '');
    setAuthToken('');
    setIsLoggedIn(false);
    setWelcomeMessage(''); // Očisti poruku dobrodošlice
    navigate(RouteNames.HOME);
  }

  const value = {
    isLoggedIn,
    authToken,
    login,
    logout,
    welcomeMessage, // Dodaj poruku dobrodošlice u kontekst
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}
