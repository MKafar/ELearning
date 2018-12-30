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
            { id: 5, title: 'E' },
            { id: 5, title: 'E' },
            { id: 6, date: '01.01.18', title: 'Kolejny długaśny bardzo długi tytuł, no bardzo długi ffffffffffffffffff ffffffffffffffffffffffff' }
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

                <div className="todayExercise">
                    <Header size='medium'> Dzisiejsze zadanie</Header>
                    <Button onClick={todayExerciseHandler}>Szczegóły</Button>
                    <Header size='medium'>Oceń innych</Header>
                    <Header size='small'>3/20</Header>
                    <Button onClick={gradeHandler}>Oceń</Button>
                </div>

                <div className="previousExercise">
                    {this.state.exercises.map((exercise) => {
                        return <DetailList
                            id={exercise.id}
                            title={exercise.title}
                            date={exercise.date} />
                    })}
                </div>
            </div>
        );
    }
}

export default StudentExercises;