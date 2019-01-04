import React, { Component } from 'react';
import { Button, Header } from 'semantic-ui-react';

import './StudentExercises.scss';

import DetailList from '../../components/Modules/DetailList'

class StudentExercises extends Component {

    state = {
        previousExercises: [
            { id: 1, title: 'Jakiś tytuł ćwiczenia' },
            { id: 2, title: 'B' },
            { id: 3, title: 'C' },
            { id: 4, title: 'D' },
            { id: 5, title: 'E' },
            { id: 6, title: 'E' },
            { id: 7, title: 'E' },
            { id: 8, date: '01.01.18', title: 'Kolejny długaśny bardzo długi tytuł, no bardzo długi ffffffffffffffffff ffffffffffffffffffffffff' }
        ],
        todaysExercise: [
            {id: 1, title: "Nowe zadanie", date: "01.01.19", variant: 1, group: "nazwa grupy"}
        ]
    }


    previousdetailsHandler = (exercisePreviousDetailID) => {
        this.props.history.push('/previousexercises/' + exercisePreviousDetailID);
    }
    todaydetailsHandler = (exerciseTodayDetailID) => {
        this.props.history.push('/todayexercise/' + exerciseTodayDetailID);
    }
    gradeOthersHandler = () => {
        this.props.history.push('/gradeothers/');
    }

    render() {

        return (
            <div className="StudentExercises">
                <div>
                    <Header size='huge'>Imię i nazwisko studenta</Header>
                    <Header size='large'>Zadania wykonane</Header>
                    <div className="previousExercise">
                        {this.state.previousExercises.map((exerciseprevious) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={false}
                                key={exerciseprevious.id}
                                title={exerciseprevious.title}
                                date={exerciseprevious.date}
                                detailsClicked={()=> this.previousdetailsHandler(exerciseprevious.id)}
                                />

                        })}
                    </div>
                </div>

                <div className="todayExercise">
                    <Header size='large'> Nowe zadanie</Header>
                    {this.state.todaysExercise.map((exercisetoday) => {
                            return <DetailList
                        visibledetail={true}
                        visibledelete={false}
                        title={exercisetoday.title}
                        key={exercisetoday.id}
                        date={exercisetoday.date}
                        variant={"Wariant: " + exercisetoday.variant}
                        group={"Grupa: " + exercisetoday.group}
                        detailsClicked={()=> this.todaydetailsHandler(exercisetoday.id)}
                         />
                        })}
                        <br />
                    <div className='gradeOthers'>
                        <Header size='medium'>Oceń innych</Header>
                        <Button className='gradebutton' onClick={this.gradeOthersHandler}>Oceń</Button>
                </div>

                </div>
            </div>
        );
    }
}

export default StudentExercises;