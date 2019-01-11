import React, { Component } from 'react';
import { Button, Header } from 'semantic-ui-react';
import axios from '../..//axios';

import './StudentExercises.scss';

import DetailList from '../../components/Modules/DetailList';

class StudentExercises extends Component {

    state = {
        previousExercises: [],
        todaysExercise: [
            {id: 1, title: "Nowe zadanie", date: "01.01.19", variant: 1, group: "nazwa grupy"}
        ]
    }
    loadData = () => {
        const userid = 2;
        axios.get('/api/Users/GetPastAssignmentsById/' +  userid)
            .then (response => {
                this.setState({previousExercises: response.data.pastassignments});
            }).catch (error =>{ 
                console.log(error.response);
            })
    }

    componentDidMount = () => {
        this.loadData();
        console.log("StudentExercises component. ComponentDidMount: ", this.props.user);
    }


    previousdetailsHandler = (previousAssignmentID) => {
        this.props.history.push('/student/previousexercises/' + previousAssignmentID);
    }
    todaydetailsHandler = (exerciseTodayDetailID) => {
        this.props.history.push('/student/todayexercise/' + exerciseTodayDetailID);
    }
    gradeOthersHandler = () => {
        this.props.history.push('/student/gradeothers/');
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
                                key={exerciseprevious.assignmentid}
                                title={exerciseprevious.exercisetitle}
                                date={exerciseprevious.date}
                                group={"Grupa: " + exerciseprevious.groupname}
                                detailsClicked={()=> this.previousdetailsHandler(exerciseprevious.assignmentid)}
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