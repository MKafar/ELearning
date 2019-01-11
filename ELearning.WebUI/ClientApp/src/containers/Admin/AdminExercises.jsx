import React, { Component } from 'react';

import './AdminExercises.scss';
import SearchExercise from '../../components/Modules/SearchExercise';
import DetailList from '../../components/Modules/DetailList';
import axios from '../../axios';
import { Button, Icon } from 'semantic-ui-react';
import ModalAddExercise from '../../components/Modules/ModalAddExercise';

class AdminExercises extends Component {

    state = {
        exercises: [],
        value: '',
        selectedItem: [],
        showSelected: false
    }

    loadData = () => {
        axios.get('/api/Exercises/GetAll')
        .then(response => {
            this.setState({ exercises: response.data.exercises })
        });
    }
    componentDidMount() {
        this.loadData();
    }


    valueHandle = (selectedValue) => {
        this.setState({ value: selectedValue });
        this.viewData(selectedValue);
        this.setState({showSelected: true});
    }

    viewData = (selectedId) => {
        //const selectedExercise = this.state.exercises.slice();
        axios.get('/api/Exercises/GetById/' + selectedId)
            .then(response => {
                this.setState({ selectedItem: response.data });
            });
    }

    reverseState = () => {
        this.setState({ showSelected: false });
    }


    detailsHandler = (exerciseDetailID) => {
        this.props.history.push('/admin/exercises/' + exerciseDetailID);
    }


    removeHandler = (exerciseRemoveID) => {
        console.log('Usuń', exerciseRemoveID);
        axios.delete('/api/Exercises/Delete/'+ exerciseRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć zadania.");
            });
    }
  
    render() {


        return (
            <div className='adminExercises'>
                <div className='searching'>
                    <div className='content'>
                        <SearchExercise
                            selectvalue={this.valueHandle} />
                    </div>
                    <Button icon onClick={this.reverseState}><Icon name='delete' /></Button>
                    {/* <Button onClick={this.addnewHandler}>Dodaj zadanie</Button> */}
                    <div className='addExercisebutton'>
                        <ModalAddExercise updateData={this.loadData} className='addExercisebutton' addHanlde={this.addnewHandler}/> 
                    </div>

                </div>

                <div className='exerciseList'>
                    {this.state.showSelected ?
                        <div>
                            <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={this.state.selectedItem.id}
                                id={this.state.selectedItem.id}
                                title={this.state.selectedItem.title}
                                detailsClicked={()=> this.detailsHandler(this.state.selectedItem.id)}
                                removeClicked={()=>this.removeHandler(this.state.selectedItem.id)} 
                                />
                        </div>
                        :
                        this.state.exercises.map((exercise) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={exercise.id}
                                id={exercise.id}
                                title={exercise.title}
                                detailsClicked={()=> this.detailsHandler(exercise.id)}
                                removeClicked={()=>this.removeHandler(exercise.id)}
                                 />
                        })
                    }
                </div>
            </div>
        );
    }
}

export default AdminExercises;