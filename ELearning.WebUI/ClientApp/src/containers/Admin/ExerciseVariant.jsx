import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';
import axios from '../../axios';

import './ExerciseVariant.scss';
import ModalAddVariant from '../../components/Modules/ModalAddVariant'
import DetailList from '../../components/Modules/DetailList'

class ExerciseVariant extends Component {

    state = {
        exerciseViariants: [],
        selectedExerciseID: null,
        selectedExerciseTitle: ''
    }

    loadData = () => {
        axios.get('/api/Exercises/GetAllVariantsById/' + this.state.selectedExerciseID)
        .then(response => {
            this.setState({ exerciseViariants: response.data.variants });
        }).catch(error => {
            console.log(error.response);
        });

        axios.get('/api/Exercises/GetById/' + this.state.selectedExerciseID)
        .then(response => {
            this.setState({ selectedExerciseTitle: response.data.title });
        }).catch(error => {
            console.log(error.response);
        });
        
    }

    componentDidMount = () => {
        this.loadData();
    }
    componentWillMount = () => {

        this.setState({selectedExerciseID: this.props.match.params.exerciseDetailsID});
    }

    detailsHandler = (exerciseVariantID) => {
        this.props.history.push('/exercises/' + this.props.match.params.exerciseDetailsID + '/' + exerciseVariantID);
    }

    removeHandler = (exerciseRemoveID) => {
        axios.delete('/api/Variants/Delete/'+ exerciseRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć wariantu");
            });
    }

    render() {


        return (
            <div className="ExerciseVariant">
                <div>
                    <Header size='huge'>
                    {this.state.selectedExerciseTitle}
                    {/* <Button.Group> 
                        <Button icon onClick={this.editHandler}>
                            <Icon name='edit' />
                        </Button>
                        <Button icon onClick={this.saveHandler}>
                            <Icon name='save' />
                        </Button>
                    </Button.Group>  */}
                    </Header>

                    <ModalAddVariant selectedExerciseID={this.state.selectedExerciseID} updateData={this.loadData} /> 

                    <div className="variants">

                        {this.state.exerciseViariants.map((variant) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={variant.variantId}
                                number={variant.variantNumber}
                                text={'Wariant: '} 
                                detailsClicked={()=> this.detailsHandler(variant.variantId)}
                                removeClicked={()=>this.removeHandler(variant.variantId)}
                                />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default ExerciseVariant;