// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
   const initPostCheckBoxes = () => {
       const dayCheckBoxes = $('.day-check-box');
       $.each(dayCheckBoxes, (id, el) => {
           $(el).on('change', (event) => {
               const chkBox = $(event.target);
               const checkState = chkBox.parent().next().prop('hidden');
               chkBox.parent().next().prop('hidden', !checkState);
           });
       });
   }
   
   const initPostWorkingTimes = () => {
       $(".working-hour-from, .working-hour-to").combodate({
           firstItem: 'name',
           minuteStep: 1,
           customClass: 'form-control'
       });
   }
   
   const submitNewPostForm = (form) => {
       const title = form.find('#PostTitle').prop('value');
       const phoneNumber = form.find('#PostPhoneNumber').prop('value');
       const email = form.find('#PostEmail').prop('value');
       const address = form.find('#PostAddress').prop('value');
       const description = form.find('#PostDescription').prop('value');
       
       const checkedBoxes = $('.day-check-box:checked');
       let times = {};
       
       $.each(checkedBoxes, (id, el) => {
           const elem = $(el);
           const comboDate = elem.parent().next().find('.combodate');
           const hourFrom = $(comboDate.get(0)).find('.hour').prop('value');
           const minuteFrom = $(comboDate.get(0)).find('.minute').prop('value');
           const hourTo = $(comboDate.get(1)).find('.hour').prop('value');
           const minuteTo = $(comboDate.get(1)).find('.minute').prop('value');
           
           times[elem.prop('id')] = {
               'hourFrom': hourFrom,
               'minuteFrom': minuteFrom,
               'hourTo': hourTo,
               'minuteTo': minuteTo
           }
       });
       console.log(times);
   }
   
   initPostCheckBoxes();
   initPostWorkingTimes();
   
   $('#new-post-form').submit((e) => {
       e.preventDefault();
       submitNewPostForm($(e.target));
   })
   
});