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

    componentDidMount() {
        axios.get('/api/Exercises/GetAll')
            .then(response => {
                this.setState({ exercises: response.data.exercises })
            });
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

    addnewHandler = () => {
        
    }

    detailsHandler = (exerciseDetailID) => {
        this.props.history.push('/exercises/' + exerciseDetailID);
    }

    removeHandler = (exerciseRemoveID) => {
        console.log('Usuń', exerciseRemoveID);
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
                        <ModalAddExercise className='addExercisebutton' addHanlde={this.addnewHandler}/> 
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