import React, { Component } from 'react';
import { Header } from 'semantic-ui-react';

import './ExerciseVariant.scss';
import ModalAddVariant from '../../components/Modules/ModalAddVariant'
import DetailList from '../../components/Modules/DetailList'

class ExerciseVariant extends Component {

    state = {
        variants: [
            { id: 1, number: 1 },
            { id: 2, number: 2 },
            { id: 3, number: 3 },
            { id: 4, number: 4 },
        ],
        selectedExerciseID: null
    }

    loadData = () => {

    }

    componentDidMount = () => {
        console.log("Zadanie:"+this.state.selectedExerciseID);
    }
    componentWillMount = () => {
        this.setState({selectedExerciseID: this.props.match.params.exerciseDetailsID});
    }

    editHandler = () => {
        console.log('Edit');
    }
    saveHandler = () => {
        console.log('Zapisz');
    }

    detailsHandler = (exerciseVariantID) => {
        this.props.history.push('/exercises/' + this.props.match.params.exerciseDetailsID + '/' + exerciseVariantID);
    }

    removeHandler = (exerciseRemoveID) => {
        console.log('Usuń', exerciseRemoveID);
    }

    render() {


        return (
            <div className="ExerciseVariant">
                <div>
                    <Header size='huge'>
                    Jakiś długi tytuł bardzo długi tytuł
                    {/* <Button.Group> 
                        <Button icon onClick={this.editHandler}>
                            <Icon name='edit' />
                        </Button>
                        <Button icon onClick={this.saveHandler}>
                            <Icon name='save' />
                        </Button>
                    </Button.Group>  */}
                    </Header>

                    <ModalAddVariant /> 

                    <div className="variants">

                        {this.state.variants.map((variant) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={true}
                                key={variant.id}
                                number={variant.number}
                                text={'Wariant: '} 
                                detailsClicked={()=> this.detailsHandler(variant.id)}
                                removeClicked={()=>this.removeHandler(variant.id)}
                                />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default ExerciseVariant;