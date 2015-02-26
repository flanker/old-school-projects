using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption","Ĺ���ż��Ǽ�")]
    public class ExcavationFeatureTomb : BaseObject
    {
        public ExcavationFeatureTomb(Session session) : base(session) { }

        [Custom("Caption","��¼��")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption","��¼����")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption","������ַ")]
        public string BelongSite
        {
            get { return GetPropertyValue<string>("BelongSite"); }
            set { SetPropertyValue("BelongSite", value); }
        }

        [Custom("Caption","Ĺ����")]
        public String Id
        {
            get { return GetPropertyValue<String>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption","�Ƿ�����")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }


        [Association("ExcavationFeatureTomb-Worker", typeof(Worker))]
        [Custom("Caption", "������Ա")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }


        [Custom("Caption","����������")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption","����������")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption","�ù�")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("EndOn", value); }
        }


        //����λ��
        [Custom("Caption","��������")]
        public string GPS
        {
            get { return GetPropertyValue<string>("GPS"); }
            set { SetPropertyValue("GPS", value); }
        }

        [Custom("Caption","����λ������һ")]
        public string GPSDescription
        {
            get { return GetPropertyValue<string>("GPSDescription"); }
            set { SetPropertyValue("GPSDescription", value); }
        }

        [Custom("Caption","��������")] //ȫվ��
        public string TotalStation
        {
            get { return GetPropertyValue<string>("TotalStation"); }
            set { SetPropertyValue("TotalStation", value); }
        }

        [Custom("Caption","����λ��������")]
        public string TotalStationDescription
        {
            get { return GetPropertyValue<string>("TotalStationDescription"); }
            set { SetPropertyValue("TotalStationDescription", value); }
        }
        
        [Custom("Caption","�����ż���")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }
        //������Ϣ
        //��Ȼ����
        [Custom("Caption","����")]
        public string Terrain
        {
            get { return GetPropertyValue<string>("Terrain"); }
            set { SetPropertyValue("Terrain", value); }
        }

        [Custom("Caption","��ò")]
        public string Landform
        {
            get { return GetPropertyValue<string>("Landform"); }
            set { SetPropertyValue("Landform", value); }
        }

        [Custom("Caption","ˮ��")]
        public string Hydrology
        {
            get { return GetPropertyValue<string>("Hydrology"); }
            set { SetPropertyValue("Hydrology", value); }
        }

        [Custom("Caption","ֲ��")]
        public string Vege
        {
            get { return GetPropertyValue<string>("Vege"); }
            set { SetPropertyValue("Vege", value); }
        }

        [Custom("Caption","����״��")]
        public string KeepState
        {
            get { return GetPropertyValue<string>("KeepState"); }
            set { SetPropertyValue("KeepState", value); }
        }

        [Custom("Caption","����ʽ")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption","�ֲ�λ��")]
        public string SpreadLocation
        {
            get { return GetPropertyValue<string>("SpreadLocation"); }
            set { SetPropertyValue("SpreadLocation", value); }
        }
        
        //�������ż���λ��λ�ù�ϵ ��Զ�

        [Custom("Caption", "�������ż���λ��λ�ù�ϵ)")]
        [Association("ExcavationFeatureTomb-Layer", typeof(Layer))]
        public XPCollection Layer
        {
            get { return GetCollection("Layer"); }
        }


        [Custom("Caption","��������")]
        public string LayerDescription
        {
            get { return GetPropertyValue<string>("LayerDescription"); }
            set { SetPropertyValue("LayerDescription", value); }
        }


        //����
        [Custom("Caption","�����ż�")]
        public string AdditionFeature
        {
            get { return GetPropertyValue<string>("AdditionFeature"); }
            set { SetPropertyValue("AdditionFeature", value); }
        }

        //�ر���

        //����ǰ

        // �ر��¶�
        [Custom("Caption","�ر��¶ȷ���")]
        public string LandSlopeLocation
        {
            get { return GetPropertyValue<string>("LandSlopeLocation"); }
            set { SetPropertyValue("LandSlopeLocation", value); }
        }
        [Custom("Caption","�ر��¶ȽǶ�")]
        public int LandSlopeDegree
        {
            get { return GetPropertyValue<int>("LandSlopeDegree"); }
            set { SetPropertyValue("LandSlopeDegree", value); }
        }

        [Custom("Caption","ƽ����״")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption","������״")]
        public string SideShape
        {
            get { return GetPropertyValue<string>("SideShape"); }
            set { SetPropertyValue("SideShape", value); }
        }

        [Custom("Caption","������״")]
        public string ProfileShape
        {
            get { return GetPropertyValue<string>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //����
        //���� 
        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter SIzeEntireIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("SIzeEntireIsLengthOrDiameter"); }
            set { SetPropertyValue("SIzeEntireIsLengthOrDiameter", value); }
        }


        [Custom("Caption","��/ֱ��")]
        public float SizeEntireLength
        {
            get { return GetPropertyValue<float>("SizeEntireLength"); }
            set { SetPropertyValue("SizeEntireLength", value); }
        }

        [Custom("Caption","��")]
        public float SizeEntireWidth
        {
            get { return GetPropertyValue<float>("SizeEntireWidth"); }
            set { SetPropertyValue("SizeEntireWidth", value); }
        }

        [Custom("Caption","��")]
        public float SizeEntireHeight
        {
            get { return GetPropertyValue<float>("SizeEntireHeight"); }
            set { SetPropertyValue("SizeEntireHeight", value); }
        }

        //����

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter SIzeSunkerIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("SIzeSunkerIsLengthOrDiameter"); }
            set { SetPropertyValue("SIzeSunkerIsLengthOrDiameter", value); }
        }
        [Custom("Caption","��/ֱ��")]
        public float SizeSunkerLength
        {
            get { return GetPropertyValue<float>("SizeSunkerLength"); }
            set { SetPropertyValue("SizeSunkerLength", value); }
        }

        [Custom("Caption","��")]
        public float SizeSunkerWidth
        {
            get { return GetPropertyValue<float>("SizeSunkerWidth"); }
            set { SetPropertyValue("SizeSunkerWidth", value); }
        }

        [Custom("Caption","��")]
        public float SizeSunkerDepth
        {
            get { return GetPropertyValue<float>("SizeSunkerDepth"); }
            set { SetPropertyValue("SizeSunkerDepth", value); }
        }

        //������
        //ʯ��
        [Custom("Caption","��Χ")]
        public string StoneRange
        {
            get { return GetPropertyValue<string>("StoneRange"); }
            set { SetPropertyValue("StoneRange", value); }
        }

        [Custom("Caption","�ʵ�")]
        public string StoneQuality
        {
            get { return GetPropertyValue<string>("StoneQuality"); }
            set { SetPropertyValue("StoneQuality", value); }
        }


        [Custom("Caption","��ɫ")]
        public string StoneColor
        {
            get { return GetPropertyValue<string>("StoneColor"); }
            set { SetPropertyValue("StoneColor", value); }
        }

        [Custom("Caption","����")]
        public string StoneProportion
        {
            get { return GetPropertyValue<string>("StoneProportion"); }
            set { SetPropertyValue("StoneProportion", value); }
        }

        [Custom("Caption","��ѡ��")]
        public int StoneClassification
        {
            get { return GetPropertyValue<int>("StoneClassification"); }
            set { SetPropertyValue("StoneClassification", value); }
        }

        [Custom("Caption","ĥԲ��")]
        public int StoneSmooth
        {
            get { return GetPropertyValue<int>("StoneSmooth"); }
            set { SetPropertyValue("StoneSmooth", value); }
        }

        [Custom("Caption","��С�ߴ�")]
        public float StoneMinSize
        {
            get { return GetPropertyValue<float>("StoneMinSize"); }
            set { SetPropertyValue("StoneMinSize", value); }
        }

        [Custom("Caption","���ߴ�")]
        public float StoneMaxSize
        {
            get { return GetPropertyValue<float>("StoneMaxSize"); }
            set { SetPropertyValue("StoneMaxSize", value); }
        }

        [Custom("Caption","ƽ���ߴ�")]
        public float StoneAverageSize
        {
            get { return GetPropertyValue<float>("StoneAverageSize"); }
            set { SetPropertyValue("StoneAverageSize", value); }
        }

        //ֲ�� һ�Զ�
        [Custom("Caption","ֲ��(��Χ-����-��ɫ-�߶�-����)")]
        [Association("ExcavationFeatureTomb-Vegetation", typeof(Vegetation))]
        public XPCollection Vegetation
        {
            get { return GetCollection("Vegetation"); }
        }
      
        //ע��:�о������ж�Ĺ������ͼ�����ܴ����Ŀ���ѧ�Ļ�
        [Custom("Caption","Ĺ������")]
        public string TombType
        {
            get { return GetPropertyValue<string>("TombType"); }
            set { SetPropertyValue("TombType", value); }
        }

        //�ѻ�  ��Զ�
       // [Custom("Caption","�ѻ����")]
        [Custom("Caption", "�ر����ѻ�")]

        [Association("ExcavationFeatureTomb-Accumulation1", typeof(Accumulation))]
        public XPCollection Accumulation1
        {
            get { return GetCollection("Accumulation1"); }
        }

        //������ ��Զ�
        [Custom("Caption", "�ر���������")]

        [Association("ExcavationFeatureTomb-RemainMark1", typeof(RemainMark))]
        public XPCollection RemainMark1
        {
            get { return GetCollection("RemainMark1"); }
        }

        //ע�⣺�����ر����������״������������ѻ�������о������ƶ�Ĺ��ر����Ľ�����ʽ���������ϡ��������̣���
        [Custom("Caption","����")]
        public string SurfaceBuildingDescription
        {
            get { return GetPropertyValue<string>("SurfaceBuildingDescription"); }
            set { SetPropertyValue("SurfaceBuildingDescription", value); }
        }



        //Ĺ��
        [Custom("Caption","Ĺ��λ��")]
        public string TombEntryPosition
        {
            get { return GetPropertyValue<string>("TombEntryPosition"); }
            set { SetPropertyValue("TombEntryPosition", value); }
        }

        [Custom("Caption","���ڲ�λ���ж�����")]
        public string TombEntryLayerAndReason
        {
            get { return GetPropertyValue<string>("TombEntryLayerAndReason"); }
            set { SetPropertyValue("TombEntryLayerAndReason", value); }
        }

        [Custom("Caption","Ĺ����״")]
        public string TombEntryShape
        {
            get { return GetPropertyValue<string>("TombEntryShape"); }
            set { SetPropertyValue("TombEntryShape", value); }
        }

        [Custom("Caption","Ĺ�ڷ���(�Ƕ�)")]
        public string TombEntryDirectionDegree
        {
            get { return GetPropertyValue<string>("TombEntryDirectionDegree"); }
            set { SetPropertyValue("TombEntryDirectionDegree", value); }
        }

        [Custom("Caption","Ĺ�ڷ���")]
        public string TombEntryDirectionOne
        {
            get { return GetPropertyValue<string>("TombEntryDirectionOne"); }
            set { SetPropertyValue("TombEntryDirectionOne", value); }
        }

        [Custom("Caption","Ĺ�ڷ���(��/ֱ��)")]
        public string TombEntryDirectionLength
        {
            get { return GetPropertyValue<string>("TombEntryDirectionLength"); }
            set { SetPropertyValue("TombEntryDirectionLength", value); }
        }

        [Custom("Caption","Ĺ�ڷ���")]
        public string TombEntryDirectionLengthTwo
        {
            get { return GetPropertyValue<string>("TombEntryDirectionLengthTwo"); }
            set { SetPropertyValue("TombEntryDirectionLengthTwo", value); }
        }

        [Custom("Caption","Ĺ�ڷ���(��)")]
        public string TombEntryDirectionLengthWidth
        {
            get { return GetPropertyValue<string>("TombEntryDirectionLengthWidth"); }
            set { SetPropertyValue("TombEntryDirectionLengthWidth", value); }
        }


        [Custom("Caption","Ĺ����״")]
        public string TombBottomShape
        {
            get { return GetPropertyValue<string>("TombBottomShape"); }
            set { SetPropertyValue("TombBottomShape", value); }
        }


        [Custom("Caption","�ӵ׷���(�Ƕ�)")]
        public string TombBottomDirectionDegree
        {
            get { return GetPropertyValue<string>("TombBottomDirectionDegree"); }
            set { SetPropertyValue("TombBottomDirectionDegree", value); }
        }


        [Custom("Caption","�ӵ׷���")]
        public string TombBottomDirectionOne
        {
            get { return GetPropertyValue<string>("TombBottomDirectionOne"); }
            set { SetPropertyValue("TombBottomDirectionOne", value); }
        }

        [Custom("Caption","�ӵ׷���(��/ֱ��)")]
        public string TombBottomDirectionLength
        {
            get { return GetPropertyValue<string>("TombBottomDirectionLength"); }
            set { SetPropertyValue("TombBottomDirectionLength", value); }
        }

        [Custom("Caption","�ӵ׷���")]
        public string TombBottomDirectionTwo
        {
            get { return GetPropertyValue<string>("TombBottomDirectionTwo"); }
            set { SetPropertyValue("TombBottomDirectionTwo", value); }
        }

        [Custom("Caption","�ӵ׷���(��)")]
        public string TombBottomDirectionWidth
        {
            get { return GetPropertyValue<string>("TombBottomDirectionWidth"); }
            set { SetPropertyValue("TombBottomDirectionWidth", value); }
        }


        //Ĺ��������״
        [Custom("Caption","Ĺ�����淽��һ")]
        public string TombProfileDirectionOne
        {
            get { return GetPropertyValue<string>("TombProfileDirectionOne"); }
            set { SetPropertyValue("TombProfileDirectionOne", value); }
        }

        [Custom("Caption","Ĺ��������״һ")]
        public string TombProfileShapeOne
        {
            get { return GetPropertyValue<string>("TombProfileShapeOne"); }
            set { SetPropertyValue("TombProfileShapeOne", value); }
        }


        [Custom("Caption","Ĺ�����淽���")]
        public string TombProfileDirectionTwo
        {
            get { return GetPropertyValue<string>("TombProfileDirectionTwo"); }
            set { SetPropertyValue("TombProfileDirectionTwo", value); }
        }

        [Custom("Caption","Ĺ��������״��")]
        public string TombProfileShapeTwo
        {
            get { return GetPropertyValue<string>("TombProfileShapeTwo"); }
            set { SetPropertyValue("TombProfileShapeTwo", value); }
        }

        //�˹��ѻ� (���-�ֲ���Χ-����(���նѻ��ǼǱ���и���))
        [Custom("Caption", "Ĺ���˹��ѻ�")]

        [Association("ExcavationFeatureTomb-Accumulation2", typeof(Accumulation))]
        public XPCollection Accumulation2
        {
            get { return GetCollection("Accumulation2"); }
        }

        //��Ȼ�ѻ�(���-�ֲ���Χ-����(���նѻ��ǼǱ���и���))
        [Custom("Caption", "Ĺ����Ȼ�ѻ�")]

        [Association("ExcavationFeatureTomb-NatureAccumulation2", typeof(NatureAccumulation))]
        public XPCollection NatureAccumulation2
        {
            get { return GetCollection("NatureAccumulation2"); }
        }


        //������(λ��-���-����-��λ-���)
        [Custom("Caption", "Ĺ�۳�����")]

        [Association("ExcavationFeatureTomb-RemainMark2", typeof(RemainMark))]
        public XPCollection RemainMark2
        {
            get { return GetCollection("RemainMark2"); }
        }

        //���⽨���ṹ�Լ��˹��ۼ�������λ�á��ṹ����״�������������������˹�����ӹ��ۼ��ȣ�
        //ע�⣺Ĺ�ڼӹ��ۼ������ѡ���ܡ�ƫ�ҡ��衢Ĺ�׹�餵ײ��̵�����ӡ�����̨��

        [Custom("Caption","���⽨���ṹ�Լ��˹��ۼ�������Ĺ�ۣ�")]

        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige", 
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige"); }
        }
      

        //ע�⣺����Ĺ����״������������ѻ���������⽨���ṹ���˹��ż�����
        //�о������ƶ�Ĺ�ӵĽ�����ʽ���ѻ��γɵĹ��̡�
        [Custom("Caption","����")]
        public string TombWallDescription
        {
            get { return GetPropertyValue<string>("TombWallDescription"); }
            set { SetPropertyValue("TombWallDescription", value); }
        }

        //Ĺ��

        //�˹��ѻ� (���-�ֲ���Χ-����(���նѻ��ǼǱ���и���))
        [Custom("Caption", "Ĺ���˹��ѻ�")]
        [Association("ExcavationFeatureTomb-Accumulation3", typeof(Accumulation))]
        public XPCollection Accumulation3
        {
            get { return GetCollection("Accumulation3"); }
        }

        //��Ȼ�ѻ� (���-�ֲ���Χ-����(���նѻ��ǼǱ���и���))
        [Custom("Caption", "Ĺ���˹��ѻ�")]
        [Association("ExcavationFeatureTomb-NatureAccumulation3", typeof(NatureAccumulation))]
        public XPCollection NatureAccumulation3
        {
            get { return GetCollection("NatureAccumulation3"); }
        }


        [Custom("Caption","��Ĺ���ڵ�λ��")]
        public string TombRoomPosition
        {
            get { return GetPropertyValue<string>("TombRoomPosition"); }
            set { SetPropertyValue("TombRoomPosition", value); }
        }

         //����

        [Custom("Caption","������")]
        public float TombRoomLength
        {
            get { return GetPropertyValue<float>("TombRoomLength"); }
            set { SetPropertyValue("TombRoomLength", value); }
        }

        [Custom("Caption","������")]
        public float TombRoomWidth
        {
            get { return GetPropertyValue<float>("TombRoomWidth"); }
            set { SetPropertyValue("TombRoomWidth", value); }
        }

        [Custom("Caption","������")]
        public float TombRoomHeight
        {
            get { return GetPropertyValue<float>("TombRoomHeight"); }
            set { SetPropertyValue("TombRoomHeight", value); }
        }

        //��� һ�Զ�(����-ƽ����״-����-����)
        [Custom("Caption", "���")]

        [Association("ExcavationFeatureTomb-TombTool", typeof(TombTool))]
        public XPCollection TombTool
        {
            get { return GetCollection("TombTool"); }
        }


        [Custom("Caption", "�������")]
        public string TombContainerDescription
        {
            get { return GetPropertyValue<string>("TombContainerDescription"); }
            set { SetPropertyValue("TombContainerDescription", value); }
        }

        //�˹� һ�Զ�(��-λ��-��ʽ-ͷ��-����)
        [Custom("Caption", "�˹�")]

        [Association("ExcavationFeatureTomb-TombSkeleton", typeof(TombSkeleton))]
        public XPCollection TombSkeleton
        {
            get { return GetCollection("TombSkeleton"); }
        }


        [Custom("Caption","�˹��໥��λ�ù�ϵ")]
        public string SkeletonRelation
        {
            get { return GetPropertyValue<string>("SkeletonRelation"); }
            set { SetPropertyValue("SkeletonRelation", value); }
        }

        //������(λ��-���-����-��λ-���)
        [Custom("Caption", "Ĺ�ҳ�����")]

        [Association("ExcavationFeatureTomb-RemainMark3", typeof(RemainMark))]
        public XPCollection RemainMark3
        {
            get { return GetCollection("RemainMark3"); }
        }

        //���⽨���ṹ�Լ��˹��ۼ�������λ�á��ṹ����״�������������������˹�����ӹ��ۼ��ȣ�
        //ע�⣺Ĺ�ڼӹ��ۼ������ѡ���ܡ�ƫ�ҡ��衢Ĺ�׹�餵ײ��̵�����ӡ�����̨��

        [Custom("Caption","���⽨���ṹ�Լ��˹��ۼ�������Ĺ�ң�")]

        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige2", 
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige2
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige2"); }
        }

        //ע�⣺����Ĺ����״������������ѻ���������⽨���ṹ���˹��ż�����
        //�о������ƶ�Ĺ�ҵĽ�����ʽ���ѻ��γɣ����ᣩ�Ĺ��̡�
        [Custom("Caption","����")]
        public string TombRoomDescription
        {
            get { return GetPropertyValue<string>("TombRoomDescription"); }
            set { SetPropertyValue("TombRoomDescription", value); }
        }

        //ѳ�� ���� ѳ�� ���� һ�Զ�(���-���-����λ��-��������-����-���-����)
        [Custom("Caption", "ѳ�� ���� ѳ�� ����")]

        [Association("ExcavationFeatureTomb-TombSacrifice", typeof(TombSacrifice))]
        public XPCollection TombSacrifice
        {
            get { return GetCollection("TombSacrifice"); }
        }


        [Custom("Caption","����")]
        public string SacrificeDescription
        {
            get { return GetPropertyValue<string>("SacrificeDescription"); }
            set { SetPropertyValue("SacrificeDescription", value); }
        }

        //���� һ�Զ� (λ��-����)
        [Custom("Caption", "����")]

        [Association("ExcavationFeatureTomb-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }


        [Custom("Caption","��������໥��ϵ")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }

        [Custom("Caption","�Ļ������ж�������")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }
        [Custom("Caption","�ż����ۡ������ܽἰ����")]
        public string Summary
        {
            get { return GetPropertyValue<string>("Summary"); }
            set { SetPropertyValue("Summary", value); }
        }
        //����� һ�Զ�

        //����� һ�Զ�

        //��ͼ�� һ�Զ�

         [Custom("Caption","��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        //Ĺ�ᷢ���¼
        [Size(3000)]
        [Custom("Caption","��Ȼ����")]
        public string Environment
        {
            get { return GetPropertyValue<string>("Environment"); }
            set { SetPropertyValue("Environment", value); }
        }

        [Size(3000)]
        [Custom("Caption","��ʷ����ſ�")]
        public string Geohistory
        {
            get { return GetPropertyValue<string>("Geohistory"); }
            set { SetPropertyValue("Geohistory", value); }
        }

        [Size(3000)]
        [Custom("Caption","��������")]
        public string PreviousWork
        {
            get { return GetPropertyValue<string>("PreviousWork"); }
            set { SetPropertyValue("PreviousWork", value); }
        }

        [Size(3000)]
        [Custom("Caption","�������")]
        public string ExcavationProcess
        {
            get { return GetPropertyValue<string>("ExcavationProcess"); }
            set { SetPropertyValue("ExcavationProcess", value); }
        }

        [Size(3000)]
        [Custom("Caption","��λ��ϵ")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }

        [Size(3000)]
        [Custom("Caption","�ر���")]
        public string SurfaceBuilding
        {
            get { return GetPropertyValue<string>("SurfaceBuilding"); }
            set { SetPropertyValue("SurfaceBuilding", value); }
        }

        [Size(3000)]
        [Custom("Caption","Ĺ��")]
        public string TombWall
        {
            get { return GetPropertyValue<string>("TombWall"); }
            set { SetPropertyValue("TombWall", value); }
        }

        [Size(3000)]
        [Custom("Caption","Ĺ��")]
        public string TombRoom
        {
            get { return GetPropertyValue<string>("TombRoom"); }
            set { SetPropertyValue("TombRoom", value); }
        }

        [Size(3000)]
        [Custom("Caption","���")]
        public string TombContainer
        {
            get { return GetPropertyValue<string>("TombContainer"); }
            set { SetPropertyValue("TombContainer", value); }
        }

        [Size(3000)]
        [Custom("Caption","�˹�")]
        public string Skeleton
        {
            get { return GetPropertyValue<string>("Skeleton"); }
            set { SetPropertyValue("Skeleton", value); }
        }

        [Size(3000)]
        [Custom("Caption","���� ��ʽ")]
        public string Rite
        {
            get { return GetPropertyValue<string>("Rite"); }
            set { SetPropertyValue("Rite", value); }
        }

        [Size(3000)]
        [Custom("Caption","����Ʒ")]
        public string Belongs
        {
            get { return GetPropertyValue<string>("Belongs"); }
            set { SetPropertyValue("Belongs", value); }
        }

        [Size(3000)]
        [Custom("Caption","����")]
        public string Other
        {
            get { return GetPropertyValue<string>("Other"); }
            set { SetPropertyValue("Other", value); }
        }

        [Size(3000)]
        [Custom("Caption","������Ļ����Ƽ��������")]
        public string AgeAndCulture
        {
            get { return GetPropertyValue<string>("AgeAndCulture"); }
            set { SetPropertyValue("AgeAndCulture", value); }
        }

        [Size(3000)]
        [Custom("Caption","��ֵ���պ����ƻ�")]
        public string ValueAndPlan
        {
            get { return GetPropertyValue<string>("ValueAndPlan"); }
            set { SetPropertyValue("ValueAndPlan", value); }
        }

        [Custom("Caption","�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption","���ʱ��")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }
    }

    public enum IsMainOrPart { δ֪, ��, �� }

}
