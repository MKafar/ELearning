import React, { Component } from 'react';
import { Header, Button, Container } from 'semantic-ui-react';
import axios from '../../axios';

import './ExerciseDetails.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import Axios from 'axios';


class ExerciseDetails extends Component {

    state = {
        assigmnentDetails: null,
        assignmentCode: null,
        exercises: [
            { number: 1, title: 'Jakiś tytuł ćwiczenia' },
        ],

    }
    loadData = () => {
        

        axios.get('/api/Assignments/GetById/' + this.props.match.params.previousAssignmentID)
            .then(response => {
                this.setState({assigmnentDetails: response.data});          
            }).catch(error => {
                 console.log(error.response);
            })

    }

    componentDidMount = () => {
        this.loadData();
    }
    descriptionHandler = () => {
        console.log('Treść');
    }

    render() {

        return (
            <div className='exerciseContainer'>
                <div className="doneExerciseCode">

                    {this.state.assigmnentDetails ?
                        <Header size='large'>{this.state.assigmnentDetails.exercisetitle}</Header>
                        : null}
                    {this.state.assigmnentDetails ?
                        <CodeWindow changeMode={true} code={this.state.assigmnentDetails.solution} />
                        : null}
                </div>
                <div className='exerciseInfo'>
                    {this.state.assigmnentDetails ?
                        <Header size='large'>Data:{this.state.assigmnentDetails.date}</Header>
                        : null}
                    <Button onClick={this.descriptionHandler}>Treść</Button>
                    {this.state.assigmnentDetails ?
                    <Container className='gradeContainer'> Ocena: {this.state.assigmnentDetails.finalgrade}</Container> 
                    : null}

                </div>
            </div>
        );
    }
}

export default ExerciseDetails;