import React, { Component } from 'react';
import { Button, Header } from 'semantic-ui-react';

import './StudentExercises.scss';

import DetailList from '../../components/Modules/DeatilList'

class StudentExercises extends Component {

    state = {
        exercises: [
            { id: 1, title: 'Jakiś tytuł ćwiczenia' },
            { id: 2, title: 'B' },
            { id: 3, title: 'C' },
            { id: 4, title: 'D' },
            { id: 5, title: 'E' },
            { id: 6, title: 'E' },
            { id: 7, title: 'E' },
            { id: 8, date: '01.01.18', title: 'Kolejny długaśny bardzo długi tytuł, no bardzo długi ffffffffffffffffff ffffffffffffffffffffffff' }
        ]
    }

    render() {
        const todayExerciseHandler = () => {
            console.log('Szczegóły');
        }
        const gradeHandler = () => {
            console.log('Oceń');
        }

        return (
            <div className="StudentExercises">
                <div>
                    <Header size='huge'>Imię i nazwisko studenta</Header>
                    <Header size='large'>Zadania wykonane</Header>
                    <div className="previousExercise">
                        {this.state.exercises.map((exercise) => {
                            return <DetailList
                                key={exercise.id}
                                id={exercise.id}
                                title={exercise.title}
                                date={exercise.date} />
                        })}
                    </div>
                </div>

                <div className="todayExercise">
                    <Header size='large'> Nowe zadanie</Header>
                    <DetailList
                        title={"Nowe zadanie"}
                        date={"01.01.19"}
                        variant={"Wariant: " + 1}
                        group={"Grupa: " + "nazwa grupy"}
                         />
                        <br />
                    <div className='gradeOthers'>
                        <Header size='medium'>Oceń innych</Header>
                        <Button className='gradebutton' onClick={gradeHandler}>Oceń</Button>
                </div>

                </div>
            </div>
        );
    }
}

export default StudentExercises;