/**
 * Autogenerated by Thrift
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;
namespace Leansoft.BigQueue.Thrift
{
  public class BigQueueService {
    public interface Iface {
      void enqueue(string topic, QueueRequest req);
      QueueResponse dequeue(string topic);
      QueueResponse peek(string topic);
      long getSize(string topic);
      bool isEmpty(string topic);
    }

    public class Client : Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      public void enqueue(string topic, QueueRequest req)
      {
        send_enqueue(topic, req);
        recv_enqueue();
      }

      public void send_enqueue(string topic, QueueRequest req)
      {
        oprot_.WriteMessageBegin(new TMessage("enqueue", TMessageType.Call, seqid_));
        enqueue_args args = new enqueue_args();
        args.Topic = topic;
        args.Req = req;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public void recv_enqueue()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        enqueue_result result = new enqueue_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

      public QueueResponse dequeue(string topic)
      {
        send_dequeue(topic);
        return recv_dequeue();
      }

      public void send_dequeue(string topic)
      {
        oprot_.WriteMessageBegin(new TMessage("dequeue", TMessageType.Call, seqid_));
        dequeue_args args = new dequeue_args();
        args.Topic = topic;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public QueueResponse recv_dequeue()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        dequeue_result result = new dequeue_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "dequeue failed: unknown result");
      }

      public QueueResponse peek(string topic)
      {
        send_peek(topic);
        return recv_peek();
      }

      public void send_peek(string topic)
      {
        oprot_.WriteMessageBegin(new TMessage("peek", TMessageType.Call, seqid_));
        peek_args args = new peek_args();
        args.Topic = topic;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public QueueResponse recv_peek()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        peek_result result = new peek_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "peek failed: unknown result");
      }

      public long getSize(string topic)
      {
        send_getSize(topic);
        return recv_getSize();
      }

      public void send_getSize(string topic)
      {
        oprot_.WriteMessageBegin(new TMessage("getSize", TMessageType.Call, seqid_));
        getSize_args args = new getSize_args();
        args.Topic = topic;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public long recv_getSize()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        getSize_result result = new getSize_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getSize failed: unknown result");
      }

      public bool isEmpty(string topic)
      {
        send_isEmpty(topic);
        return recv_isEmpty();
      }

      public void send_isEmpty(string topic)
      {
        oprot_.WriteMessageBegin(new TMessage("isEmpty", TMessageType.Call, seqid_));
        isEmpty_args args = new isEmpty_args();
        args.Topic = topic;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        oprot_.Transport.Flush();
      }

      public bool recv_isEmpty()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        isEmpty_result result = new isEmpty_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "isEmpty failed: unknown result");
      }

    }
    public class Processor : TProcessor {
      public Processor(Iface iface)
      {
        iface_ = iface;
        processMap_["enqueue"] = enqueue_Process;
        processMap_["dequeue"] = dequeue_Process;
        processMap_["peek"] = peek_Process;
        processMap_["getSize"] = getSize_Process;
        processMap_["isEmpty"] = isEmpty_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private Iface iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void enqueue_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        enqueue_args args = new enqueue_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        enqueue_result result = new enqueue_result();
        iface_.enqueue(args.Topic, args.Req);
        oprot.WriteMessageBegin(new TMessage("enqueue", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void dequeue_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        dequeue_args args = new dequeue_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        dequeue_result result = new dequeue_result();
        result.Success = iface_.dequeue(args.Topic);
        oprot.WriteMessageBegin(new TMessage("dequeue", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void peek_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        peek_args args = new peek_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        peek_result result = new peek_result();
        result.Success = iface_.peek(args.Topic);
        oprot.WriteMessageBegin(new TMessage("peek", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void getSize_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        getSize_args args = new getSize_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        getSize_result result = new getSize_result();
        result.Success = iface_.getSize(args.Topic);
        oprot.WriteMessageBegin(new TMessage("getSize", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void isEmpty_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        isEmpty_args args = new isEmpty_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        isEmpty_result result = new isEmpty_result();
        result.Success = iface_.isEmpty(args.Topic);
        oprot.WriteMessageBegin(new TMessage("isEmpty", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    [Serializable]
    public partial class enqueue_args : TBase
    {
      private string _topic;
      private QueueRequest _req;

      public string Topic
      {
        get
        {
          return _topic;
        }
        set
        {
          __isset.topic = true;
          this._topic = value;
        }
      }

      public QueueRequest Req
      {
        get
        {
          return _req;
        }
        set
        {
          __isset.req = true;
          this._req = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool topic;
        public bool req;
      }

      public enqueue_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Topic = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.Struct) {
                Req = new QueueRequest();
                Req.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("enqueue_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Topic != null && __isset.topic) {
          field.Name = "topic";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Topic);
          oprot.WriteFieldEnd();
        }
        if (Req != null && __isset.req) {
          field.Name = "req";
          field.Type = TType.Struct;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          Req.Write(oprot);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("enqueue_args(");
        sb.Append("Topic: ");
        sb.Append(Topic);
        sb.Append(",Req: ");
        sb.Append(Req== null ? "<null>" : Req.ToString());
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class enqueue_result : TBase
    {

      public enqueue_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("enqueue_result");
        oprot.WriteStructBegin(struc);

        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("enqueue_result(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class dequeue_args : TBase
    {
      private string _topic;

      public string Topic
      {
        get
        {
          return _topic;
        }
        set
        {
          __isset.topic = true;
          this._topic = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool topic;
      }

      public dequeue_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Topic = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("dequeue_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Topic != null && __isset.topic) {
          field.Name = "topic";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Topic);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("dequeue_args(");
        sb.Append("Topic: ");
        sb.Append(Topic);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class dequeue_result : TBase
    {
      private QueueResponse _success;

      public QueueResponse Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool success;
      }

      public dequeue_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Struct) {
                Success = new QueueResponse();
                Success.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("dequeue_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.Struct;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            Success.Write(oprot);
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("dequeue_result(");
        sb.Append("Success: ");
        sb.Append(Success== null ? "<null>" : Success.ToString());
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class peek_args : TBase
    {
      private string _topic;

      public string Topic
      {
        get
        {
          return _topic;
        }
        set
        {
          __isset.topic = true;
          this._topic = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool topic;
      }

      public peek_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Topic = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("peek_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Topic != null && __isset.topic) {
          field.Name = "topic";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Topic);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("peek_args(");
        sb.Append("Topic: ");
        sb.Append(Topic);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class peek_result : TBase
    {
      private QueueResponse _success;

      public QueueResponse Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool success;
      }

      public peek_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Struct) {
                Success = new QueueResponse();
                Success.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("peek_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.Struct;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            Success.Write(oprot);
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("peek_result(");
        sb.Append("Success: ");
        sb.Append(Success== null ? "<null>" : Success.ToString());
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class getSize_args : TBase
    {
      private string _topic;

      public string Topic
      {
        get
        {
          return _topic;
        }
        set
        {
          __isset.topic = true;
          this._topic = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool topic;
      }

      public getSize_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Topic = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("getSize_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Topic != null && __isset.topic) {
          field.Name = "topic";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Topic);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("getSize_args(");
        sb.Append("Topic: ");
        sb.Append(Topic);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class getSize_result : TBase
    {
      private long _success;

      public long Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool success;
      }

      public getSize_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.I64) {
                Success = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("getSize_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.I64;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("getSize_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class isEmpty_args : TBase
    {
      private string _topic;

      public string Topic
      {
        get
        {
          return _topic;
        }
        set
        {
          __isset.topic = true;
          this._topic = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool topic;
      }

      public isEmpty_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Topic = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("isEmpty_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Topic != null && __isset.topic) {
          field.Name = "topic";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Topic);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("isEmpty_args(");
        sb.Append("Topic: ");
        sb.Append(Topic);
        sb.Append(")");
        return sb.ToString();
      }

    }


    [Serializable]
    public partial class isEmpty_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      [Serializable]
      public struct Isset {
        public bool success;
      }

      public isEmpty_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("isEmpty_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.Bool;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("isEmpty_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }

  }
}
