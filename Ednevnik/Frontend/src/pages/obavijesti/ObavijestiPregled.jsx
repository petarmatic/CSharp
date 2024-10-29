import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import Service from "../../services/ObavijestService"; 
import { RouteNames } from "../../constants";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";

export default function ObavijestiPregled() {
    const [obavijesti, setObavijesti] = useState([]); 
    let navigate = useNavigate();

    async function dohvatiObavijesti() {
        await Service.get()
            .then((odgovor) => {
                console.log(odgovor); 
                setObavijesti(odgovor); 
            })
            .catch((e) => {
                console.log(e);
            });
    }

    async function obrisiObavijest(id) {
        const odgovor = await Service.obrisi(id);
        if (odgovor.greska) {
            prikaziError(odgovor.poruka); 
            return;
        }
        dohvatiObavijesti(); 
    }

    useEffect(() => {
        dohvatiObavijesti();
    }, []);

    return (
        <Container>
            <Link to={RouteNames.OBAVIJEST_DODAJ} className="btn btn-success siroko">
                <IoIosAdd size={25} /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Tekst</th>
                        <th>Datum</th>
                        <th>Predmet</th>
                        <th>Akcije</th>
                    </tr>
                </thead>
                <tbody>
                    {obavijesti.map((entitet, index) => (
                        <tr key={index}>
                            <td>{entitet.tekst}</td>
                            <td>{entitet.datum}</td>
                            <td>{entitet.predmetNaziv}</td>
                            <td className="sredina">
                                <Button
                                    variant='primary'
                                    onClick={() => { navigate(`/obavijesti/${entitet.id}`) }}
                                >
                                    <FaEdit size={25} />
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant='danger'
                                    onClick={() => obrisiObavijest(entitet.id)}
                                >
                                    <FaTrash size={25} />
                                </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}
