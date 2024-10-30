import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import Service from "../../services/OcjenaService"; 
import { RouteNames } from "../../constants";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import useError from "../../hooks/useError"; 

export default function OcjenePregled() {
    const [ocjene, setOcjene] = useState([]);
    const { prikaziError } = useError(); 
    let navigate = useNavigate();

    async function dohvatiOcjene() {
        await Service.get()
            .then((odgovor) => {
                console.log(odgovor); 
                setOcjene(odgovor); 
            })
            .catch((e) => {
                console.log(e);
            });
    }

    async function obrisiOcjene(id) {
        const odgovor = await Service.obrisi(id);
        if (odgovor.greska) {
            prikaziError(odgovor.poruka); 
            return;
        }
        dohvatiOcjene(); 
    }

    useEffect(() => {
        dohvatiOcjene();
    }, []);

    return (
        <Container>
            <Link to={RouteNames.OCJENA_DODAJ} className="btn btn-success siroko">
                <IoIosAdd size={25} /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Učenik</th>
                        <th>Predmet</th>
                        <th>Vrijednost ocjene</th>
                        <th>Datum</th>
                        <th>Akcije</th>
                    </tr>
                </thead>
                <tbody>
                    {ocjene.map((entitet, index) => (
                        <tr key={index}>
                            <td>{entitet.ucenikIme}</td>
                            <td>{entitet.predmetNaziv}</td>
                            <td>{entitet.vrijednostOcjena}</td>
                            <td>{entitet.datum}</td> 
                            <td className="sredina">
                                <Button
                                    variant='primary'
                                    onClick={() => { navigate(`/ocjene/${entitet.id}`) }}
                                >
                                    <FaEdit size={25} />
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                    variant='danger'
                                    onClick={() => obrisiOcjene(entitet.id)} 
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
