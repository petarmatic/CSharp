import { Button, Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom"; 
import { RouteNames } from "../../constants";
import PredmetService from "../../services/PredmetService";

export default function PredmetiPregled() {
    const [predmeti, setPredmeti] = useState([]);
    const navigate = useNavigate();

    async function dohvatiPredmete() {
        const odgovor = await PredmetService.get();
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        setPredmeti(odgovor.poruka); 
    }

    useEffect(() => {
        dohvatiPredmete();
    }, []);

    return (
        <>
            <Link to={RouteNames.PREDMET_NOVI} className="btn btn-success">
                OVDJE IDE DODAJ predmet
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Naziv</th>
                        <th>Akcije</th>
                    </tr>
                </thead>
                <tbody>
                    {predmeti&&predmeti.map((e, index) => (
                        <tr key={index}>
                            <td>{e.naziv}</td>
                            <td>
                                <Button
                                    variant="primary"
                                    onClick={() => navigate(`/predmeti/${e.id}`)}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant="danger"
                                    onClick={() => obrisi(e.id)}>
                                    Obriši
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </>
    );
}
