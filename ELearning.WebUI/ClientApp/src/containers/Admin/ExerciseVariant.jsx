import React, { Component } from 'react';
import { Button, Header, Icon, ButtonGroup } from 'semantic-ui-react';

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
        ]
    }

    editHandler = () => {
        console.log('Edit');
    }
    saveHandler = () => {
        console.log('Zapisz');
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
                                text={'Wariant: '} />
                        })}
                    </div>
                </div>
            </div>
        );
    }
}

export default ExerciseVariant;