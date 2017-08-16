using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class TaskListVM
    {
        //主表数据
        public string RequestNo { get; set; }  //审批编号 
        public DateTime CreateDate { get; set; }  //创建日期
        public string Applicant { get; set; }  //申请人
        public int Status { get; set; }  //项目状态

        //Message表数据
        public string Sender { get; set; }  //发信人
        public string Context { get; set; }  //消息内容
        public string MessageDate { get; set; }   //发信时间   
        public string MessageType { get; set; }   //消息类型
        public string CommentStatusName { get; set; }  //审批状态
    }
}