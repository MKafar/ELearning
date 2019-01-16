import React, { Component } from 'react';
import { Button, Header } from 'semantic-ui-react';
import axios from '../..//axios';
import {withRouter} from 'react-router';

import './StudentExercises.scss';

import DetailList from '../../components/Modules/DetailList';

class StudentExercises extends Component {

    state = {
        previousExercises: [],
        todaysExercise: [],
    }
    loadData = () => {
        console.log("user: ",this.props.user);
        const userid = this.props.user.userid;
        axios.get('/api/Users/GetPastAssignmentsById/' +  userid)
            .then (response => {
                this.setState({previousExercises: response.data.pastassignments});
            }).catch (error =>{ 
                console.log(error.response);
            })
        
        axios.get('/api/Users/GetPresentAssignmentsById/' + userid)
            .then (response => {
                console.log('Present',response.data);
                this.setState({todaysExercise: response.data.presentassignments});
            }).catch(error => {
                console.log(error.response);
            })
    }

    componentDidMount = () => {
        this.loadData();
        console.log("StudentExercises component. ComponentDidMount: ", this.props);
    }


    previousdetailsHandler = (previousAssignmentID) => {
        this.props.history.push({
            pathname: '/student/previousexercises/' + previousAssignmentID,
        });
    }
    todaydetailsHandler = (exerciseTodayDetailID) => {
        this.props.history.push('/student/todayexercise/' + exerciseTodayDetailID);
    }
    gradeOthersHandler = (exerciseTodayDetailID) => {
        this.props.history.push('/student/gradeothers/' + exerciseTodayDetailID);
        console.log(this.state.todaysExercise.assignmentid)

    }

    render() {

        return (
            <div className="StudentExercises">
                <div>
                    <Header size='huge'>Witaj {this.props.user.username}!</Header>
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
                                detailsClicked={() => this.previousdetailsHandler(exerciseprevious.assignmentid)}
                            />

                        })}
                    </div>
                </div>

                <div className="todayExercise">
                    <Header size='large'> Nowe zadanie</Header>
                    {
                        this.state.todaysExercise.map((exercisetoday) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={false}
                                title={exercisetoday.exercisetitle}
                                key={exercisetoday.assignmentid}
                                date={exercisetoday.date}
                                group={"Grupa: " + exercisetoday.groupname}
                                detailsClicked={() => this.todaydetailsHandler(exercisetoday.assignmentid)}
                            />
                        })
                    }
                    < br />
                
                    <div className='gradeOthers'>
                        <Header size='medium'>Oceń innych</Header>
                        {this.state.todaysExercise.map((exercisetoday) => {
                         return <Button  key={exercisetoday.assignmentid} className='gradebutton' onClick={() => this.gradeOthersHandler(exercisetoday.assignmentid)}>Oceń</Button> }) }
                    </div> 
                </div>
            </div>
        );
    }
}

export default withRouter(StudentExercises);