import axios from "axios";
import React, { Component } from "react";

export default class TurmasAdm extends Component{
    constructor(props) {
        super(props);

        this.state = {
            nomeTurma: '',
            inscricaos: [],
            

            idInscricao: 0,

            ListarTurmas: [],
            ListarInscricoes: {},
            isLoading: false,
        };
    };

    buscarTurmas = () => {
        axios('http://localhost:5000/api/TurmasControllers',{
            headers:{
                Autorization: 'Bearer' + localStorage.getItem('usuario-login'),
            },
        })

        .then((resposta) =>{
            if(resposta.status === 200){
                this.setState({ListarTurmas: resposta.data});
                console.log(this.state.ListarTurmas)
            }
        })
        .catch((erro) => console.log(erro));
    };
    buscarInscricoes = () =>{
        axios('http://localhost:5000/api/InscricoesControllers')
        .then((resposta) => {
            if (resposta.status ===200) {
                this.setState({ ListarInscricoes: resposta.data});
                console.log(this.state. ListarInscricoes);
            }
        })
        .catch((erro) => console.log(erro));
    };
    atualizaStateCampo = (campo) => {
        this.setState({[campo.target.name]: campo.target.value});
    };
    componentDidMount() {
        console.log('inicia ciclo da vida');
        this.buscarTurmas();
        console.log()
        this.buscarInscricoes();
    };

    render() {
        return(
            <>
            <main>
                <section>
                    <h2>Lista de turmas</h2>
                    <table style={{borderCollapse: 'separate', borderSpacing: 30 }}>
                    <thead>
                                <tr>
                                    <th>#</th>
                                    <th>id curso</th>
                                    <th>Nome turma</th>
                                    <th>Inscrições</th>
                                </tr>
                            </thead>

                            <tbody>
                                {this.state.ListarTurmas.map((evento)=>{
                                    return(
                                        <tr key={evento.idTurma}>
                                            <td>{evento.idTurma}</td>
                                            <td>{evento.idCurso}</td>
                                            <td>{evento.nomeTurma}</td>
                                            <td>{evento.idInscricao}</td>
                                            <td>{evento.idInscricao}</td>

                                        </tr>
                                    )
                                })}
                            </tbody>
                    </table>
                </section>
            </main>
            </>
        )
    }
}