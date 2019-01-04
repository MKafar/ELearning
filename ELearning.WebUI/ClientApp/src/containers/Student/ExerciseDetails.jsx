import React, { Component } from 'react';
import { Header, Button, Container } from 'semantic-ui-react';

import './ExerciseDetails.scss';
import CodeWindow from '../../components/Modules/CodeWindow';


class ExerciseDetails extends Component {

    state = {
        exercises: [
            { number: 1, title: 'Jakiś tytuł ćwiczenia' },
        ],

    }

    render() {

        const descriptionHandler = () => {
            console.log('Treść');
        }

        return (
            <div className='exerciseContainer'>
                <div className="doneExerciseCode">
                    <Header size='large'>Temat zadania</Header>
                    <CodeWindow changeMode={true} code={'Hello'} />
                </div>
                <div className='exerciseInfo'>
                    <Header size='large'>Data</Header>
                    <Button onClick={descriptionHandler}>Treść</Button>
                    <Container className='gradeContainer'> Ocena: 5.0</Container>

                </div>
            </div>
        );
    }
}

export default ExerciseDetails;